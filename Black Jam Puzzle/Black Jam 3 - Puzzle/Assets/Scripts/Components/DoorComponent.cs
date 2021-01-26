using UnityEngine;
using DG.Tweening;

using Mikabrytu.BJ3.Systems;

namespace Mikabrytu.BJ3.Components
{
    public class DoorComponent : MonoBehaviour, IEntrance
    {
        [SerializeField] private Transform _entrance;
        [SerializeField] private Vector2 _direction;
        [SerializeField] private string[] _allowedTags;

        private NavigationSystem navigationSystem;

        private void Start()
        {
            navigationSystem = new NavigationSystem(_allowedTags, _direction);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            navigationSystem.ChangeRoom(collision, transform);
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, _direction, Color.green);
        }

        public Vector2 GetRoomPosition()
        {
            return transform.parent.position;
        }

        public Transform GetEntrancePosition()
        {
            return _entrance;
        }
    }
}
