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

        public void TurnCycle(Color color, float intensity, float speed)
        {
            _light.DOColor(color, speed);
            _light.DOIntensity(intensity, speed);
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