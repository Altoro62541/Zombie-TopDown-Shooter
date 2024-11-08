using Zenject;
using UnityEngine;
using ZombieShooter.HealthSystem;
using ZombieShooter.PlayerEntity;
using ZombieShooter.ZombieEntity.SO;
using System;
using ZombieShooter.AI.ZombieAI;
using ZombieShooter.StateMachine.ZombieStates;
namespace ZombieShooter.ZombieEntity
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(Despawn))]
    [RequireComponent(typeof(ZombieAI))]
    [RequireComponent (typeof(ZombieStateMachine))]
    public class Zombie : MonoBehaviour, IZombie
    {
        [Inject] private IPlayer _player;

        private HealthComponent _healthComponent;
        private IZombieAI _ai;
        private IZombieStateMachine _stateMachine;
        [SerializeField] private ZombieData _data;

        public IHealthComponent HeathComponent => _healthComponent;

        public IZombieAI AI => _ai;

        public IZombieStateMachine StateMachine => _stateMachine;

        private void Awake()
        {
            if (_data is null)
            {
                throw new NullReferenceException(nameof(_data));
            }
            _healthComponent = GetComponent<HealthComponent>();
            _ai = GetComponent<IZombieAI>();
            _stateMachine = GetComponent<IZombieStateMachine>();
            _healthComponent.SetMaxHealth(_data.Health);
            _healthComponent.SetHealth(_data.Health);
        }

    }

}
