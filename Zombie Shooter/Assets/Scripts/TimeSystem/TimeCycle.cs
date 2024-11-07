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
        [SerializeField, Range(0, 23)] private float _hour = 1;

        public Color Color => _color;
        public float Intensity => _intensity;

        public float Hour => _hour;

        public DateTime StartTime
        {
            get
            {
                DateTime time = new();
                time = time.AddHours(_hour);
                return time;
            }
        }
    }
}
