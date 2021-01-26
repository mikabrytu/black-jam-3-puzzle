using UnityEngine;

namespace Mikabrytu.BJ3.Components
{
    public interface IVisitor
    {
        void Teleport(Transform position);
    }
}