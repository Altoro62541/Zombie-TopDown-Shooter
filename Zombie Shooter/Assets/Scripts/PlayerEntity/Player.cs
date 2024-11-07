using UnityEngine;
using ZombieShooter.HealthSystem;
namespace ZombieShooter.PlayerEntity
{
    [RequireComponent(typeof(PlayerRotation))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(HealthComponent))]
    public class Player : MonoBehaviour, IPlayer
    {
        private IHealthComponent _healthComponent;

        public IHealthComponent HeathComponent => _healthComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<IHealthComponent>();
        }
    }

}