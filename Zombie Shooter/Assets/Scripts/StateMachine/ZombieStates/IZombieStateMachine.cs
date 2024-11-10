using ZombieShooter.PlayerEntity;
using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    public interface IZombieStateMachine : IStateMachine<Zombie>
    {

        void TurnWandering();
        void TurnIdle();
        void TurnMoveToPlayer(IPlayer player);
        void TurnMeleeAttackPlayer(IPlayer player);
    }
}