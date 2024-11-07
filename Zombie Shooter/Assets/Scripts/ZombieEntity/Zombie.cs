using Zenject;
using UnityEngine;
using ZombieShooter.HealthSystem;
using ZombieShooter.PlayerEntity;
using ZombieShooter.ZombieEntity.SO;
using System;
namespace ZombieShooter.ZombieEntity
{
    [RequireComponent(typeof(HealthComponent))]
    public class Zombie : MonoBehaviour, IZombie
    {
      //  [Inject] private IPlayer _player;

        private HealthComponent _healthComponent;

        [SerializeField] private ZombieData _data;

        public IHealthComponent HeathComponent => _healthComponent;

        private void Awake()
        {
            if (_data is null)
            {
                throw new NullReferenceException(nameof(_data));
            }
            _healthComponent = GetComponent<HealthComponent>();
            _healthComponent.SetMaxHealth(_data.Health);
            _healthComponent.SetHealth(_data.Health);
        }

    }

}
