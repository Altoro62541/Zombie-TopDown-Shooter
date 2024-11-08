using UniRx;
using Unity.Burst.Intrinsics;

namespace ZombieShooter.PlayerEntity.PlayerStatsSystem
{
    public interface IPlayerStats
    {
        public ReactiveProperty<float> Hungry { get; }
        public ReactiveProperty<float> Sleep { get; }
        public ReactiveProperty<float> Reason { get; }
        public ReactiveProperty<float> Thirst { get; }
        public ReactiveProperty<float> Warm { get; }
    }
}