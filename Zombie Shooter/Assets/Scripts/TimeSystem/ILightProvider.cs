using UnityEngine;

namespace ZombieShooter.TimeSystem
{
    public interface ILightProvider
    {
        public Color Color { get; set; }
        public float Intensity { get; set; }
    }
}