using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;
using ZombieShooter.Configs;
using ZombieShooter.ZombieEntity;

namespace ZombieShooter.AI.ZombieAI
{
    [RequireComponent (typeof(NavMeshAgent))]
    public class ZombieAI : MonoBehaviour, IZombieAI
    {
        private NavMeshAgent _agent;
        [SerializeField] private NavMeshAgentConfig _config;
        private IZombie _mainComponent;

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
            _mainComponent = GetComponent<IZombie>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.stoppingDistance = _config.StopDistance;
            _agent.acceleration = _config.Acceleration;
            _agent.updateRotation = _config.UpdateRotatiion;
            _agent.angularSpeed = _config.AngularSpeed;
            _agent.speed = _mainComponent.Data.SpeedMove;
        }

        public void MoveTo(Vector3 point)
        {
            _agent.isStopped = false;
            _agent.SetDestination(point);
        }

        public void MoveTo(Transform transform)
        {
            MoveTo(transform.position);
        }

        public void Stop ()
        {
            _agent.isStopped = true;
        }


    }
}