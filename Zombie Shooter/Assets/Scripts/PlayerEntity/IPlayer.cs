using ZombieShooter.Factories;
using ZombieShooter.HealthSystem;
using ZombieShooter.PlayerEntity.SO;

namespace ZombieShooter.PlayerEntity
{
    public interface IPlayer : IPositionable, ITransformable, IFactoryObject
    {
        PlayerData Data { get; }
        IHealthComponent HeathComponent { get; }
        
    }
}
