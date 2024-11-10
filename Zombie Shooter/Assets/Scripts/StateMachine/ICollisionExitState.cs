using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZombieShooter.States
{
    public interface ICollisionExitState
    {
        void CollisionExit(Collision collision);
    }
}
