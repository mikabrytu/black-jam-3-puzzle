using System;
using System.Linq;
using UnityEngine;

namespace Mikabrytu.BJ3.Systems
{
    public class MapSystem
    {
        private Transform[] rooms;
        private Transform[] positions;
        private int[] ids;
        private int scale;

        public MapSystem(Transform[] rooms, Transform[] positions, int[] ids, int scale)
        {
            this.rooms = rooms;
            this.positions = positions;
            this.ids = ids;
            this.scale = scale;
        }

        public void Shuffle()
        {
            SetMatrix();
        }

        private void SetMatrix()
        {
            int empty = (scale * scale) - ids.Length;
            int[] shuffled = new int[empty + ids.Length];

            for (int i = 0; i < shuffled.Length; i++)
                shuffled[i] = (i >= ids.Length) ? 0 : ids[i];

            shuffled = shuffled.OrderBy(c => Guid.NewGuid()).ToArray();

            Populate(shuffled);
        }

        private void Populate(int[] list)
        {
            int[,] matrix = new int[scale, scale];

            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = list[index];

                    if (matrix[i, j] > 0)
                    {
                        rooms[matrix[i, j] - 1].position = positions[index].position;
                    }

                    index++;
                }
        }
    }
}
