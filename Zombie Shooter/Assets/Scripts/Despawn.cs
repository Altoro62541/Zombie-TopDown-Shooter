using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Threading;
using UnityEngine;
using Zenject;
using ZombieShooter.Configs;
using ZombieShooter.Extensions;
using ZombieShooter.HealthSystem;
namespace ZombieShooter
{
    public class Despawn : MonoBehaviour, IDespawn
    {
        private CancellationTokenSource _cancellationTokenSource;
        [Inject] DespawnConfig _config;
        [SerializeField] private bool _isActive = true;
        [SerializeField] private bool _useDOTween = true;
        [SerializeField, MinValue(0.1f)] private float _time = 60;
        private IHealthComponent _healthComponent;



        public float Time { get => _time; set => _time = value; }

        public bool IsActive
        {
            get
            {
                return _isActive;
            }

            set
            {
                _isActive = value;
                SetStatrDespawn();
            }
        }

        private void Awake()
        {
            TryGetComponent(out _healthComponent);
        }

        private void Start()
        {
            SetStatrDespawn();
        }

        private void SetStatrDespawn ()
        {
            if (_isActive)
            {
                _cancellationTokenSource = new();
                DespawnDelay().Forget();
            }

            else
            {
                _cancellationTokenSource?.Cancel();
            }
        }

        private async UniTask DespawnDelay ()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Time);
            await UniTask.Delay(timeSpan);
            Remove();
        }

        private void Remove()
        {
            if (_useDOTween)
            {
                MonoBehaviourExtensions.DODestroy(this, _config.Speed);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDead()
        {
            IsActive = false;
            Remove();
        }

        private void OnEnable()
        {
            if (_healthComponent != null)
            {
                _healthComponent.OnDead += OnDead;
            }
        }

        private void OnDisable()
        {
            if (_healthComponent != null)
            {
                _healthComponent.OnDead -= OnDead;
            }
        }
    }
}

