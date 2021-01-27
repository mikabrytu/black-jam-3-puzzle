using System;
using System.Linq;
using UnityEngine;

using Mikabrytu.BJ3.Systems;

namespace Mikabrytu.BJ3.Components
{
    public class MapComponent : MonoBehaviour, IMap
    {
        [SerializeField] private Transform[] _rooms;
        [SerializeField] private Transform[] _positions;
        [SerializeField] private int[] _ids;
        [SerializeField] private int _matrixScale;

        private MapSystem mapSystem;

        private void Start()
        {
            mapSystem = new MapSystem(_rooms, _positions, _ids, _matrixScale);
        }

        public void GenerateMap()
        {
            mapSystem.Shuffle();
        }
    }
}
