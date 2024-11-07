using UnityEngine;

namespace ZombieShooter.TimeSystem
{
    public interface ILightProvider
    {
        void TurnCycle(Color color, float intensity, float speed);
    }
}