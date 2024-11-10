using UniRx;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.HealthSystem
{
    public interface IHealthComponent
    {

        IReadOnlyReactiveProperty<float> Health { get; }
        IReadOnlyReactiveProperty<float> MaxHealth { get; }

        public void Damage (float damage, object damager = null);
    }
}