using UnityEngine;

namespace ZombieShooter.AI
{
    public interface IAI : IEnabledComponent
    {
        void MoveTo(Vector3 point);
        void MoveTo(Transform transform);
        void Stop();

        bool IsEndingMove { get; }
    }
}
