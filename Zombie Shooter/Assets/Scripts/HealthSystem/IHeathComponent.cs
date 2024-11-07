using UniRx;

namespace ZombieShooter.HealthSystem
{
    public interface IHeathComponent
    {

        IReadOnlyReactiveProperty<float> Health { get; }
        IReadOnlyReactiveProperty<float> MaxHealth { get; }

        public void Damage (float damage, object damager = null);
    }
}