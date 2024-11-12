using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.Configs
{
    [CreateAssetMenu(menuName = "Configs/VFX/Light Player")]
    public class LightPlayerVFXConfig : ScriptableConfig
    {
        [SerializeField, MinValue(0)] private float _speedFade = 0.5f;
        [SerializeField, MinValue(0)] private float _targrtIntensity = 0.3f;

        public float SpeedFade => _speedFade;

        public float TargrtIntensity => _targrtIntensity;
    }
}