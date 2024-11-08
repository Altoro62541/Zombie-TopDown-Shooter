using UnityEngine;

namespace ZombieShooter.States
{
    public interface ICollisionStayState
    {
        void CollisionStay(Collision collision);
    }
}
