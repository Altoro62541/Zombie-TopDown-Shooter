using ZombieShooter.States;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.StateMachine.ZombieStates
{
    public interface IZombieStateMachine : IStateMachine<Zombie>
    {
        void TurnWandering();
        void TurnIdle();
    }
}