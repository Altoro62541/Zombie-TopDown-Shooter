using System;
using UniRx;

namespace ZombieShooter.HealthSystem
{
    public interface IHealthComponent
    {
        event Action OnDead;
        IReadOnlyReactiveProperty<float> Health { get; }
        IReadOnlyReactiveProperty<float> MaxHealth { get; }

        public void Damage (float damage, object damager = null);
    }
}