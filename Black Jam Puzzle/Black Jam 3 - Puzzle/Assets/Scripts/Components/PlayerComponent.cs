using UnityEngine;
using DG.Tweening;

using Mikabrytu.BJ3.Events;
using Mikabrytu.BJ3.Systems;

namespace Mikabrytu.BJ3.Components
{
    public class PlayerComponent : MonoBehaviour, IPlayer
    {
        [SerializeField] private Transform _originalPosition;
        [SerializeField] private Transform _picker;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _speed = 10f;

        private MoveSystem moveSystem;
        private bool canMove = true;

        private void Start()
        {
            moveSystem = new MoveSystem(transform, _animator, _speed);
        }

        private void Update()
        {
            if (canMove)
            {
                float h = Input.GetAxisRaw("Horizontal");

                if (h != 0)
                {
                    Vector2 pickerPosition = _picker.localPosition;
                    pickerPosition.x = h;
                    _picker.localPosition = pickerPosition;
                }

                moveSystem.Move(new Vector2(h, Input.GetAxis("Vertical")));
            }

            // TODO: Remove this DEBUG
            if (Input.GetMouseButtonDown(0))
                EventManager.Raise(new OnPickableDropEvent());
        }

        public void ResetPlayer()
        {
            transform.position = _originalPosition.position;
        }

        public Vector3 GetPosition()
        {
            return _picker.position;
        }

        public void Teleport(Transform position)
        {
            GetComponent<Collider2D>().enabled = false;
            canMove = false;

            transform
                .DOMove(position.position, .25f)
                .OnComplete(() => {
                    GetComponent<Collider2D>().enabled = true;
                    canMove = true;
                });
        }
    }
}
