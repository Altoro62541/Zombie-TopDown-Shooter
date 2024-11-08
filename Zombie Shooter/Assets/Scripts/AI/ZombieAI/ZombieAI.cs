using UnityEngine;
using UnityEngine.AI;

namespace ZombieShooter.AI.ZombieAI
{
    [RequireComponent (typeof(NavMeshAgent))]
    public class ZombieAI : MonoBehaviour, IZombieAI
    {
        private NavMeshAgent _agent;


        private void Awake()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
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