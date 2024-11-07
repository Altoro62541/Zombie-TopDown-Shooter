using UnityEngine;
using ZombieShooter.HealthSystem;
namespace ZombieShooter.PlayerEntity
{
    [RequireComponent(typeof(PlayerRotation))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(HealthComponent))]
    public class Player : MonoBehaviour, IPlayer
    {
        private IHeathComponent _healthComponent;

        public IHeathComponent HeathComponent => _healthComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<IHeathComponent>();
        }
    }

}