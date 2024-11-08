using ZombieShooter.Factories;
using ZombieShooter.HealthSystem;

namespace ZombieShooter.PlayerEntity
{
    public interface IPlayer : IPositionable, ITransformable, IFactoryObject
    {
        IHealthComponent HeathComponent { get; }
        
    }
}
