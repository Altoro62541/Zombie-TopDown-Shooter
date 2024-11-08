using UnityEngine;

namespace ZombieShooter.States
{
    public interface ICollisionState : ICollisionEnterState, ICollisionExitState, ICollisionStayState
    {
    }
}
