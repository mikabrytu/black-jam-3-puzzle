using UnityEngine;

using Mikabrytu.BJ3.Systems;

namespace Mikabrytu.BJ3.Components
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private MoveSystem moveSystem;

        private void Start()
        {
            moveSystem = new MoveSystem(transform, _speed);
        }

        private void Update()
        {
            moveSystem.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical")));
        }
    }
}
