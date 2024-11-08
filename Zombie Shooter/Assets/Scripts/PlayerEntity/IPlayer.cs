using ZombieShooter.HealthSystem;

namespace ZombieShooter.PlayerEntity
{
    public interface IPlayer : IPositionable
    {
        IHealthComponent HeathComponent { get; }
        
    }
}
