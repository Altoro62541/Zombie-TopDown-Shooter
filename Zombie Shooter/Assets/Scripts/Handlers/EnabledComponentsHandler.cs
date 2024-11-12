using UnityEngine;
using ZombieShooter.HealthSystem;

namespace ZombieShooter.Handlers
{
    public class EnabledComponentsHandler : MonoBehaviour
    {
        private IEnabledComponent[] _enabledComponents;
        private IHealthComponent _healthComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _enabledComponents = GetComponents<IEnabledComponent>();
        }

        private void OnDead()
        {
            foreach (var component in _enabledComponents)
            {
                component.Enabled = false;
            }
        }

        private void OnEnable()
        {
            _healthComponent.OnDead += OnDead;
        }

        private void OnDisable()
        {
            _healthComponent.OnDead -= OnDead;
        }
    }
}
