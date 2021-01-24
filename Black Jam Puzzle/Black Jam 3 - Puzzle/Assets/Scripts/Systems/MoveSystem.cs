using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.BJ3.Systems
{
    public class MoveSystem
    {
        private Transform target;
        private float speed;

        public MoveSystem(Transform target, float speed)
        {
            this.target = target;
            this.speed = speed;
        }

        public void Move(Vector3 vector)
        {
            target.Translate(vector * speed * Time.deltaTime);
        }

        #region Debug

        public void UpdateSpeed(float speed)
        {
            this.speed = speed;
        }

        #endregion
    }
}
