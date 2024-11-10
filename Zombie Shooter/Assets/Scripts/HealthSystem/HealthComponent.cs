using UniRx;
using UnityEngine;
using System;

namespace ZombieShooter.HealthSystem
{
    public class HealthComponent : MonoBehaviour, IHealthComponent
    {
        [SerializeField] private FloatReactiveProperty _health = new();
        [SerializeField] private FloatReactiveProperty _maxHealth = new();
        public Subject<object> OnHit = new Subject<object>();

        public IReadOnlyReactiveProperty<float> Health => _health;

        public IReadOnlyReactiveProperty<float> MaxHealth => _maxHealth;

        public void Damage(float damage, object damager = null)
        {
            if (damage > 0)
            {
                OnHit?.OnNext(damage);
            }

            else
            {
                throw new ArgumentException("damage must between 0");
            }

            _health.Value = Mathf.Clamp(_health.Value - damage, 0, _maxHealth.Value);
        }

        public void SetHealth (float health)
        {
            _health.Value = Mathf.Clamp(health, 0, _maxHealth.Value);
        }

        public void SetMaxHealth(float health)
        {
            _maxHealth.Value = Mathf.Clamp(health, 0, float.MaxValue);
        }

        private void OnValidate()
        {
            _health.Value = Mathf.Clamp(_health.Value, 0, _maxHealth.Value);
        }
    }
}