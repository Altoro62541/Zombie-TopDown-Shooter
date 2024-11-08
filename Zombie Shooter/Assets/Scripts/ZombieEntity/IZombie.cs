using ZombieShooter.AI.ZombieAI;
using ZombieShooter.Factories;
using ZombieShooter.HealthSystem;
using ZombieShooter.StateMachine.ZombieStates;

namespace ZombieShooter.ZombieEntity
{
    public interface IZombie : IFactoryObject
    {
        IHealthComponent HeathComponent { get; }
        IZombieAI AI { get; }
        IZombieStateMachine StateMachine { get; }
    }
}