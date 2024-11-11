using UnityEditor;
using UnityEngine;

namespace ZombieShooter.PlayerEntity.SO
{
    [CreateAssetMenu(menuName = "Player/New Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float _speedMove;

        public float Health => _health;
        public float SpeedMove => _speedMove;
    }
}