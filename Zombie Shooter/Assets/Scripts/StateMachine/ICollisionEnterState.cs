using UnityEngine;

namespace ZombieShooter.States
{
    public interface ICollisionEnterState
    {
        void CollisionEnter(Collision collision);
    }
}
