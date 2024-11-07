using ZombieShooter.HealthSystem;

namespace ZombieShooter.ZombieEntity
{
    public interface IZombie
    {
        IHealthComponent HeathComponent { get; }
    }
}