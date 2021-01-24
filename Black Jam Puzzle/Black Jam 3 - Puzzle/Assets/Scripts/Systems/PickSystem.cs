using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.BJ3.Systems
{
    public class PickSystem
    {
        private Transform transform;
        private Collider2D collider;
        private IPicker picker;
        private string[] allowed;
        private bool isMoving;

        public PickSystem(Transform transform, Collider2D collider, string[] allowed)
        {
            this.transform = transform;
            this.collider = collider;
            this.allowed = allowed;
        }

        public void Register(Collider2D other)
        {
            if (allowed.Length > 0)
                foreach (string tag in allowed)
                {
                    picker = other.GetComponent<IPicker>();

                    if (picker != null && other.tag.Equals(tag))
                    {
                        collider.enabled = false;
                        isMoving = true;
                        break;
                    }
                }
        }

        public void Unregister()
        {
            isMoving = false;
            picker = null;
            transform.GetComponent<MonoBehaviour>().StartCoroutine(DelayPhysics());
        }

        public void Follow()
        {
            if (isMoving)
                transform.position = picker.GetPosition();
        }

        private IEnumerator DelayPhysics()
        {
            yield return new WaitForSeconds(1f);
            collider.enabled = true;
        }
    }
}
