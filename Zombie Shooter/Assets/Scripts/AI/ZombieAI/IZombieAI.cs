using UnityEngine;

namespace ZombieShooter.AI.ZombieAI
{
    public interface IZombieAI : IAI
    {
        Vector3 SteeringTarget { get; }
    }
}