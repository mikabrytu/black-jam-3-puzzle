using UnityEngine;
using DG.Tweening;

using Mikabrytu.BJ3.Components;

namespace Mikabrytu.BJ3.Systems
{
    public class NavigationSystem
    {
        private string[] allowed;
        private Vector2 direction;

        public NavigationSystem(string[] allowed, Vector2 direction)
        {
            this.allowed = allowed;
            this.direction = direction;
        }

        public void ChangeRoom(Collider2D collider, Transform transform)
        {
            foreach (string tag in allowed)
                if (collider.tag.Equals(tag))
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 2);
                    IEntrance next = hit.collider.GetComponent<IEntrance>();
                    IVisitor visitor = collider.GetComponent<IVisitor>();

                    if (hit.collider != null && next != null)
                    {
                        TeleportVisitor(visitor, next);

                        Vector3 position = next.GetRoomPosition();
                        position.z = -10;
                        Camera.main.transform.DOMove(position, .5f);
                    }

                    break;
                }
        }

        private void TeleportVisitor(IVisitor visitor, IEntrance next)
        {
            if (visitor != null)
                visitor.Teleport(next.GetEntrancePosition());
        }
    }
}
