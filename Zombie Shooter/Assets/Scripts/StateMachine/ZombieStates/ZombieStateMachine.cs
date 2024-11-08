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
            throw new System.NotImplementedException();
        }

        public void TurnWandering()
        {
            throw new System.NotImplementedException();
        }
    }
}