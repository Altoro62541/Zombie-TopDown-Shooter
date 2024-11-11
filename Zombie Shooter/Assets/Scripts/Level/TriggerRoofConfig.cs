using Sirenix.OdinInspector;
using UnityEngine;
namespace ZombieShooter.Level
{
    [CreateAssetMenu(menuName = "Level/RoofConfig")]
    public class TriggerRoofConfig : ScriptableObject
    {
        [SerializeField, MinValue(0.1f)] private float _speed = 1f;
        public float Speed => _speed;
    }
}
