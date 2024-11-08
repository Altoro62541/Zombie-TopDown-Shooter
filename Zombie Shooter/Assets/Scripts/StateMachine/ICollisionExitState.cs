using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZombieShooter.States
{
    public interface ICollisionExitState
    {
        UniTask CollisionExit(Collision collision);
    }
}
