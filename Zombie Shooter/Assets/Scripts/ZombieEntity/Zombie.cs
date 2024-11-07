using Zenject;
using UnityEngine;
using ZombieShooter.HealthSystem;
using ZombieShooter.PlayerEntity;
namespace ZombieShooter.ZombieEntity
{
    [RequireComponent(typeof(HealthComponent))]
    public class Zombie : MonoBehaviour, IZombie
    {
        [Inject] private IPlayer _player;

        private IHeathComponent _healthComponent;

        public IHeathComponent HeathComponent => _healthComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<IHeathComponent>();
        }

    }

}
