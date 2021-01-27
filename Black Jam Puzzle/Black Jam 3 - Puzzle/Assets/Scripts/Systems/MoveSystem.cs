using UnityEngine;

namespace Mikabrytu.BJ3.Systems
{
    public class MoveSystem
    {
        private Transform target;
        private Animator animator;
        private float speed;

        public MoveSystem(Transform target, Animator animator, float speed)
        {
            this.target = target;
            this.animator = animator;
            this.speed = speed;
        }

        public void Move(Vector3 vector)
        {
            animator.SetInteger("X axis", (int)vector.x);
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
