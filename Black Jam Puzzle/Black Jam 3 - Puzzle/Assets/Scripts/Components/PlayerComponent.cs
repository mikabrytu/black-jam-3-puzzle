using UnityEngine;

using Mikabrytu.BJ3.Events;
using Mikabrytu.BJ3.Systems;

namespace Mikabrytu.BJ3.Components
{
    public class PlayerComponent : MonoBehaviour, IPicker
    {
        [SerializeField] private Transform _picker;
        [SerializeField] private float _speed = 10f;

        private MoveSystem moveSystem;

        private void Start()
        {
            moveSystem = new MoveSystem(transform, _speed);
        }

        private void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");

            if (h != 0)
            {
                Vector2 pickerPosition = _picker.localPosition;
                pickerPosition.x = h;
                _picker.localPosition = pickerPosition;
            }

            moveSystem.Move(new Vector2(h, Input.GetAxis("Vertical")));

            // TODO: Remove this DEBUG
            if (Input.GetMouseButtonDown(0))
                EventManager.Raise(new OnPickableDropEvent());
        }

        public Vector3 GetPosition()
        {
            return _picker.position;
        }
    }
}
