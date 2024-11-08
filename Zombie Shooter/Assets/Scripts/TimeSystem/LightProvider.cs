using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using ZombieShooter.Extensions;

namespace ZombieShooter.TimeSystem
{
    [RequireComponent(typeof(Light2D))]
    public class LightProvider : MonoBehaviour, ILightProvider
    {
        [SerializeField] private Light2D _light;
        private Sequence _curreentSequence;

        public void TurnCycle(Color color, float intensity, float speed)
        {
            if (speed > 0)
            {
                _curreentSequence?.Kill();
                _curreentSequence = DOTween.Sequence();
                _curreentSequence.Append(_light.DOColor(color, speed));
                _curreentSequence.Join(_light.DOIntensity(intensity, speed));
                _curreentSequence.Play();
            }
            else
            {
                _light.intensity = intensity;
                _light.color = color;
            }
        }

        private void OnValidate()
        {
            if (_light is null)
            {
                _light = GetComponent<Light2D>();
            }
        }
    }
}