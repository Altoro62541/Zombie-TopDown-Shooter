using UnityEngine;
using ZombieShooter.HealthSystem;
using ZombieShooter.ZombieEntity.SO;
using System;
using ZombieShooter.AI.ZombieAI;
using ZombieShooter.StateMachine.ZombieStates;
using ZombieShooter.Handlers;
namespace ZombieShooter.ZombieEntity
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(Despawn))]
    [RequireComponent(typeof(ZombieAI))]
    [RequireComponent (typeof(ZombieStateMachine))]
    [RequireComponent(typeof(ZombieRotation))]
    [RequireComponent(typeof(ZombiePhysics))]
    [RequireComponent(typeof(Despawn))]
    [RequireComponent(typeof(EnabledComponentsHandler))]
    public class Zombie : MonoBehaviour, IZombie
    {
        private HealthComponent _healthComponent;
        private ZombieAI _ai;
        private IZombieStateMachine _stateMachine;
        [SerializeField] private ZombieData _data;
        private IZombiePhysics _zombiePhysics;

        public IHealthComponent HeathComponent => _healthComponent;

        public IZombieAI AI => _ai;

        public IZombieStateMachine StateMachine => _stateMachine;

        public IZombiePhysics ZombiePhysics => _zombiePhysics;

        public ZombieData Data => _data;

        public Vector3 Position => transform.position;

        public Transform Transform => transform;

        private void Awake()
        {
            if (_data is null)
            {
                throw new NullReferenceException(nameof(_data));
            }
            _healthComponent = GetComponent<HealthComponent>();
            _ai = GetComponent<ZombieAI>();
            _stateMachine = GetComponent<IZombieStateMachine>();
            _zombiePhysics = GetComponent<IZombiePhysics>();
            _healthComponent.SetMaxHealth(_data.Health);
            _healthComponent.SetHealth(_data.Health);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Position, _data.VisionRadius);
        }

        private void OnEnable()
        {
            
        }

    }

}
