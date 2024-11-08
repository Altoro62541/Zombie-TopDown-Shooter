using UnityEngine;

namespace ZombieShooter
{
    public interface IWorld
    {
        Vector3 GetRandomTilePosition(Vector3? center = null, float radius = float.MaxValue);
    }
}