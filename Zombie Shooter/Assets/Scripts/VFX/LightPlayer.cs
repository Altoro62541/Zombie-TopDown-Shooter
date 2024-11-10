using Cysharp.Threading.Tasks;
using DG.Tweening;
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
        private Tween _tween;
        [SerializeField] private LightPlayerVFXConfig _config;
        [Inject] private ILightProvider _lightProvider;


        private void Awake()
        {
            _light = GetComponent<Light2D>();
            _defaultIntensity = _light.intensity;
        }

        private void Start()
        {
            _light.intensity = _lightProvider.CurrentIntensity <= _config.TargrtIntensity ? _defaultIntensity : 0;
            ObserveIntensity().Forget();
        }

        private async UniTask ObserveIntensity ()
        {
            while (_light != null)
            {
                await UniTask.WaitForEndOfFrame(this);
                float targetValue = _lightProvider.CurrentIntensity <= _config.TargrtIntensity ? _defaultIntensity : 0;
                _tween?.Kill();
                _tween = _light.DOIntensity(targetValue, _config.SpeedFade);
            }
        }
    }
}