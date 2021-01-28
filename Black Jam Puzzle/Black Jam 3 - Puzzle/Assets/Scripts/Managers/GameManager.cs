using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mikabrytu.BJ3.Components;
using Mikabrytu.BJ3.Events;
using Mikabrytu.BJ3.View;

namespace Mikabrytu.BJ3
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private IPlayer _player;
        [SerializeField] private IMap _map;
        //[SerializeField] private IDisplay _timeLoopDisplay;
        [SerializeField] private float _maxTime = 120;

        private int lockedRooms = 3;
        private float time = 0;
        private float totalTime;
        private bool isRunning = false;

        private const string SCORE_KEY = "SCORE_KEY";

        private void Start()
        {
            GetScore();
            GenerateMap();

            EventManager.AddListener<OnTimeLoopStartEvent>(PrepareTimeLoop);
            EventManager.AddListener<OnMasterRoomUnlockEvent>(UnlockMasterRoom);
        }

        private void Update()
        {
            if (isRunning)
            {
                time -= Time.deltaTime;
                //_timeLoopDisplay.UpdateDisplay(time);

                if (time <= 0)
                    FinishTimeLoop();
            }
        }

        #region Game Flow

        private void GetScore()
        {
            float score = PlayerPrefs.GetFloat(SCORE_KEY, 0);
            // TODO: Display somewhere
        }

        private void GenerateMap()
        {
            _map.GenerateMap();
        }

        private void PrepareTimeLoop(OnTimeLoopStartEvent e)
        {
            if (isRunning)
                return;

            ResetTimeLoop();
            StartTimeLoop();
        }

        private void UnlockMasterRoom(OnMasterRoomUnlockEvent e)
        {
            lockedRooms--;
            if (lockedRooms == 0)
            {
                StopTimeLoop();
                ResetTimeLoop();
                SaveScore();
                EndGame();
            }
        }

        private void UpdateScore()
        {
            totalTime += _maxTime;
        }

        private void SaveScore()
        {
            float current = PlayerPrefs.GetFloat(SCORE_KEY, 0);

            if (current > 0 && totalTime < current)
            {
                PlayerPrefs.SetFloat(SCORE_KEY, totalTime + (_maxTime - time));
                PlayerPrefs.Save();
            }
        }

        private void EndGame()
        {
            // TODO: Say something to player
        }

        #endregion

        private void ResetTimeLoop()
        {
            time = _maxTime;
        }

        private void StartTimeLoop()
        {
            isRunning = true;
        }

        private void StopTimeLoop()
        {
            isRunning = false;
        }

        private void FinishTimeLoop()
        {
            isRunning = false;

            UpdateScore();
            GenerateMap();

            Camera.main.transform.position = new Vector3(0, 0, -10);
            _player.ResetPlayer();
        }
    }
}
