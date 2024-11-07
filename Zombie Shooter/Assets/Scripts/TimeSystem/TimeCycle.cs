using Sirenix.OdinInspector;
using System;
using UnityEngine;
namespace ZombieShooter.TimeSystem
{
    [Serializable]
    public class TimeCycle
    {
        [SerializeField] private Color _color = Color.white;
        [SerializeField, MinValue(0)] private float _intensity = 1;

        public Color Color => _color;
        public float Intensity => _intensity;
    }
}
