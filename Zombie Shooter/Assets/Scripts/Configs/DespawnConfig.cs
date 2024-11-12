using UnityEditor;
using UnityEngine;

namespace ZombieShooter.Configs
{
    [CreateAssetMenu(menuName = "Configs/Despawn Config")]
    public class DespawnConfig : ScriptableConfig
    {
        [SerializeField] private float _speed = 0.3f;

        public float Speed => _speed;
    }
}