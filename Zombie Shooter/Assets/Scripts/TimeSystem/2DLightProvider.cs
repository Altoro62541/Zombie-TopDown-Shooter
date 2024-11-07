using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ZombieShooter.TimeSystem
{
    [RequireComponent(typeof(Light2D))]
    public class LightProvider : MonoBehaviour, ILightProvider
    {
        [SerializeField] private Light2D _light;

        public Color Color { get => _light.color; set => _light.color = value; }
        public float Intensity { get => _light.intensity; set => _light.intensity = value; }

        private void OnValidate()
        {
            if (_light is null)
            {
                _light = GetComponent<Light2D>();
            }
        }
    }
}