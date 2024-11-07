using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.ZombieEntity.SO
{
    [CreateAssetMenu]
    public class ZombieData : ScriptableObject
    {
        [SerializeField, MinValue(1)] private float _health;
        [SerializeField, MinValue(0.1f)] private float _speedMove;

        public float Health => _health;
        public float SpeedMove => _speedMove;
    }
}