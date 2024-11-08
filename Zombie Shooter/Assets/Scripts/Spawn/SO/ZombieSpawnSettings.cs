using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.Spawn.SO
{
    [CreateAssetMenu]
    public class ZombieSpawnSettings : ScriptableObject
    {
        [SerializeField, MinValue(0)] private float _spawnRadius = 5f;
        [SerializeField] private AnimationCurve _curveSpawn;

        public float RandomTimeSpawn
        {
            get
            {
                float min = _curveSpawn[0].value;
                float max = _curveSpawn[1].value;
                return Random.Range(min, max);
            }
        }

        public float SpawnRadius => _spawnRadius;
    }
}