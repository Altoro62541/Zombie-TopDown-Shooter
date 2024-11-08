using ZombieShooter.PlayerEntity.PlayerStatsSystem;

namespace PlayerEntity.PlayerStatsSystem.Handlers
{
    public interface IPlayerStatsHandler
    {
        IPlayerStats Stats { get; }
    }
}