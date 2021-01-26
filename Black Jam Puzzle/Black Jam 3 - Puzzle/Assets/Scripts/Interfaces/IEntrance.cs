using UnityEngine;

namespace Mikabrytu.BJ3.Components
{
    public interface IEntrance
    {
        Vector2 GetRoomPosition();
        Transform GetEntrancePosition();
    }
}