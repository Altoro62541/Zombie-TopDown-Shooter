using UnityEngine;
using ZombieShooter.PlayerEntity.PlayerStatsSystem;

namespace PlayerEntity.PlayerStatsSystem.Handlers
{
    public class PlayerStatsHandler : MonoBehaviour, IPlayerStatsHandler
    {
        [SerializeField]   private PlayerStats _stats = new();

        public IPlayerStats Stats => _stats;
    }
}