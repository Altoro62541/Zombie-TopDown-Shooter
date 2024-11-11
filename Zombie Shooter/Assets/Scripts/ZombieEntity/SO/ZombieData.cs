using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.ZombieEntity.SO
{
    [CreateAssetMenu(menuName = "Zombie/New Data")]
    public class ZombieData : ScriptableObject
    {
        [SerializeField, MinValue(1)] private float _health;
        [SerializeField, MinValue(1)] private float _damage = 1;
        [SerializeField, MinValue(0.1f)] private float _speedMove;
        [SerializeField, MinValue(0.1f)] private float _speedAttack = 2;
        [SerializeField, MinValue(0.1f)] private float _ditanceAggresive = 7;
        [SerializeField, MinValue(0.1f)] private float _visionRadius = 6;

        public float Health => _health;
        public float SpeedMove => _speedMove;

        public float VisionRadius => _visionRadius;

        public float SpeedAttack => _speedAttack;
        public float DitanceAggresive => _ditanceAggresive;

        public float Damage => _damage;
    }
}