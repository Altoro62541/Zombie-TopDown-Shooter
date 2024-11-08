using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;
using ZombieShooter.Configs;

namespace ZombieShooter.AI.ZombieAI
{
    [RequireComponent (typeof(NavMeshAgent))]
    public class ZombieAI : MonoBehaviour, IZombieAI
    {
        private NavMeshAgent _agent;
        [SerializeField] private NavMeshAgentConfig _config;

        public bool IsEndingMove
        {
            get
            {
                return !_agent.pathPending &&
                       _agent.remainingDistance <= _agent.stoppingDistance;
            }
        }

        public Vector3 SteeringTarget => _agent.steeringTarget;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.stoppingDistance = _config.StopDistance;
            _agent.acceleration = _config.Acceleration;
            _agent.updateRotation = _config.UpdateRotatiion;
            _agent.angularSpeed = _config.AngularSpeed;
        }

        public void MoveTo(Vector3 point)
        {
            _agent.SetDestination(point);
        }

        public void MoveTo(Transform transform)
        {
            MoveTo(transform.position);
        }


    }
}