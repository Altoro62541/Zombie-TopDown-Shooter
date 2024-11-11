using UnityEngine;
using ZombieShooter.HealthSystem;
using ZombieShooter.PlayerEntity.SO;
namespace ZombieShooter.PlayerEntity
{
    [RequireComponent(typeof(PlayerRotation))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent (typeof(PlayerSpriteHandler))]
    public class Player : MonoBehaviour, IPlayer
    {
        private HealthComponent _healthComponent;
        private PlayerMovement _movement;

        [SerializeField] private PlayerData _playerData;

        public IHealthComponent HeathComponent => _healthComponent;

        public Vector3 Position => transform.position;

        public Transform Transform => transform;

        public PlayerData Data => _playerData;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _movement = GetComponent<PlayerMovement>();
            _healthComponent.SetMaxHealth(_playerData.Health);
            _healthComponent.SetHealth(_playerData.Health);
            _movement.Speed = _playerData.SpeedMove;
        }
    }

}