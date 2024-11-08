using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter.Configs
{
    [CreateAssetMenu(menuName = "Configs/Nav Mesh Agent Config")]
    public class NavMeshAgentConfig : ScriptableObject
    {
        [SerializeField, MinValue(0)] private float _stopDistance = 0.1f;
        [SerializeField, MinValue(0)] private float _stopMagnitude = 0.15f;
        [SerializeField, MinValue(0)] private float _angularSpeed = float.MaxValue;
        [SerializeField, MinValue(1)] private float _acceleration = float.MaxValue;
        [SerializeField] private bool _updateRotatiion;

        public float StopDistance => _stopDistance;
        public float AngularSpeed => _angularSpeed;
        public float Acceleration => _acceleration;
        public bool UpdateRotatiion => _updateRotatiion;

        public float StopMagnitude => _stopMagnitude;
    }
}