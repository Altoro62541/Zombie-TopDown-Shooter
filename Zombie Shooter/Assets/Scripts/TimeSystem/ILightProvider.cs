using UnityEngine;

namespace ZombieShooter.TimeSystem
{
    public interface ILightProvider
    {
        float CurrentIntensity { get; }
        void TurnCycle(Color color, float intensity, float speed);
    }
}