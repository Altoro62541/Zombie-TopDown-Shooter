using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;
using ZombieShooter.Configs;
using ZombieShooter.Extensions;
namespace ZombieShooter.VFX
{
    public class FlickeringLight : MonoBehaviour
    {
    [Inject] private LightFlickerConfig lightFlickerConfig;
    private Light2D _light;
    private Tween _tween;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
    }

    private void Start()
    {
        StartBrokenFlicker().Forget();
    }

    private async UniTask StartBrokenFlicker()
    {
        while (_light != null)
        {
            if (Random.value < lightFlickerConfig.BlackoutChance)
            {
                _tween?.Kill();
                _light.intensity = 0;
                await UniTask.Delay((int)(lightFlickerConfig.BlackoutDuration * 1000), cancellationToken: this.GetCancellationTokenOnDestroy());
            }
            else
            {
                float targetIntensity = Random.Range(lightFlickerConfig.MinIntensity, lightFlickerConfig.MaxIntensity);

                _tween?.Kill();
                _tween = _light.DOIntensity(targetIntensity, lightFlickerConfig.FlickerSpeed);

                await UniTask.Delay((int)((lightFlickerConfig.FlickerSpeed + lightFlickerConfig.FlickersDelay) * 1000), cancellationToken: this.GetCancellationTokenOnDestroy());
            }
        }
    }
    }
}

