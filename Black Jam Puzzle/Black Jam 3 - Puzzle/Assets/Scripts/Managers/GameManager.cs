using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mikabrytu.BJ3.Components;
using Mikabrytu.BJ3.View;

namespace Mikabrytu.BJ3
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private IPlayer _player;
        [SerializeField] private IDisplay _timeLoopDisplay;
        [SerializeField] private float _maxTime = 120;

        private float time = 0;
        private bool isRunning = false;

        private void Start()
        {
            ResetTimeLoop();
            StartTimeLoop();
        }

        private void Update()
        {
            if (isRunning)
            {
                time -= Time.deltaTime;
                _timeLoopDisplay.UpdateDisplay(time);

                if (time <= 0)
                    FinishTimeLoop();
            }
        }

        private void ResetTimeLoop()
        {
            time = _maxTime;
        }

        private void StartTimeLoop()
        {
            isRunning = true;
        }

        private void FinishTimeLoop()
        {
            isRunning = false;
            _player.ResetPlayer();
        }
    }
}
