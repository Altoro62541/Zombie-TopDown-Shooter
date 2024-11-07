using ZombieShooter.HealthSystem;

namespace ZombieShooter.ZombieEntity
{
    public interface IZombie
    {
        IHeathComponent HeathComponent { get; }
    }
}