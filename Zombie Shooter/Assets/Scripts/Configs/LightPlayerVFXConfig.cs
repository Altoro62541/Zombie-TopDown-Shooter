using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.Configs
{
    [CreateAssetMenu(menuName = "Configs/VFX/Light Player")]
    public class LightPlayerVFXConfig : ScriptableObject
    {
        [SerializeField, MinValue(0)] private float _speedFade = 0.5f;

        public float SpeedFade => _speedFade;
    }
}