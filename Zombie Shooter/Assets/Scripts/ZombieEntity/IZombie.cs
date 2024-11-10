using ZombieShooter.AI.ZombieAI;
using ZombieShooter.Factories;
using ZombieShooter.HealthSystem;
using ZombieShooter.StateMachine.ZombieStates;
using ZombieShooter.ZombieEntity.SO;

namespace ZombieShooter.ZombieEntity
{
    public interface IZombie : IFactoryObject, IPositionable, ITransformable
    {
        IHealthComponent HeathComponent { get; }
        IZombieAI AI { get; }
        IZombieStateMachine StateMachine { get; }
        ZombieData Data { get; }
    }
}