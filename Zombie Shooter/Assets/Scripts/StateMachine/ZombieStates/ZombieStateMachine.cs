using Zenject;
using ZombieShooter.PlayerEntity;
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

        public void TurnMoveToPlayer(IPlayer player)
        {
            var state = GetState<ZombieMoveToPlayerState>();
            state.SetData(player);
            SetState<ZombieMoveToPlayerState>();
        }

        public void TurnMeleeAttackPlayer(IPlayer player)
        {
            var state = GetState<ZombieMeleeAttackState>();
            state.SetData(player);
            SetState<ZombieMeleeAttackState>();
        }
    }
}