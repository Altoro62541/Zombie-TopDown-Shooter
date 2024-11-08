using System.Collections;
using UnityEngine;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    public class ZombieStateMachine : StateMachine<Zombie>, IZombieStateMachine
    {
        public void TurnIdle()
        {
            SetState<ZombieIdleState>();
        }

        public void TurnWandering()
        {
            SetState<ZombieWanderingState>();
        }
    }
}