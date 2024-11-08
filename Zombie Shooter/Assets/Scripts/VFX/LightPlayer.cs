using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;
using ZombieShooter.Configs;
using ZombieShooter.Extensions;
using ZombieShooter.TimeSystem;

namespace ZombieShooter.VFX
{
    [RequireComponent(typeof(Light2D))]
    public class LightPlayer : MonoBehaviour
    {
        private float _defaultIntensity;
        private Light2D _light;
        [SerializeField] private LightPlayerVFXConfig _config;
        [Inject] private ITimeHandler _timeHandler;

        private void Awake()
        {
            _light = GetComponent<Light2D>();
            _defaultIntensity = _light.intensity;
        }

        private void Start()
        {
            _light.intensity = _timeHandler.IsLastCurrentCycle ? _defaultIntensity : 0;
        }

        private void OnNewCycle(TimeCycle obj)
        {
            float targetValue = _timeHandler.IsLastCurrentCycle ? _defaultIntensity : 0;
            _light.DOIntensity(targetValue, _config.SpeedFade);
        }

        private void OnEnable()
        {
            _timeHandler.OnNewCycle += OnNewCycle;
        }

        private void OnDisable()
        {
            _timeHandler.OnNewCycle -= OnNewCycle;
        }
    }
}