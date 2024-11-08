using UnityEngine;

namespace ZombieShooter.AI
{
    public interface IAI
    {
        void MoveTo(Vector3 point);
        void MoveTo(Transform transform);

        bool IsEndingMove { get; }
    }
}
