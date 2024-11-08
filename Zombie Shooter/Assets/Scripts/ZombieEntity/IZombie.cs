using ZombieShooter.Factories;
using ZombieShooter.HealthSystem;

namespace ZombieShooter.ZombieEntity
{
    public interface IZombie : IFactoryObject
    {
        IHealthComponent HeathComponent { get; }
    }
}