using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.Configs
{
    [CreateAssetMenu(menuName = "Configs/VFX/Flickering Light")]
    public class LightFlickerConfig : ScriptableConfig
    {

        [Header("Intensity Settings")]
    [SerializeField, MinValue(0f)] private float _minIntensity = 0.1f;
    [SerializeField, MinValue(0.1f)] private float _maxIntensity = 1.5f;

        [Header("Flicker Settings")]
    [SerializeField, MinValue(0.1f)] private float _flickerSpeed = 0.3f;
    [SerializeField, MinValue(0.1f)] private float _flickersDelay = 0.2f;

        [Header("Blackout Settings")]
    [SerializeField, Range(0f, 1f)] private float _blackoutChance = 0.2f;
        [SerializeField, MinValue(0.1f)] private float _blackoutDuration = 1.0f;


    public float MinIntensity => _minIntensity;
    public float MaxIntensity => _maxIntensity;
    public float FlickerSpeed => _flickerSpeed;
    public float FlickersDelay => _flickersDelay;
    public float BlackoutChance => _blackoutChance;
    public float BlackoutDuration => _blackoutDuration;
        
    }
}