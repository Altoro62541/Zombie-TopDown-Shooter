using UniRx;
using Unity.Burst.Intrinsics;

namespace ZombieShooter.PlayerEntity.PlayerStatsSystem
{
    public interface IPlayerStats
    {
        public FloatReactiveProperty Hungry { get; }
        public FloatReactiveProperty Sleep { get; }
        public FloatReactiveProperty Mentai { get; }
        public FloatReactiveProperty Thirst { get; }
        public FloatReactiveProperty Warm { get; }
    }
}