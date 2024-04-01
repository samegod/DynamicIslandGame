using UnityEngine;
using UnityEngine.AI;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public class EntityMotion : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private float speed;

        private Rigidbody _rigidbody;

        public float CurrentSpeed => _rigidbody.velocity.magnitude;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            navMeshAgent.speed = speed;
        }

        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        public void MoveTo(Vector3 targetPosition)
        {
            navMeshAgent.SetDestination(targetPosition);
        }

        public void Stop()
        {
            if (navMeshAgent.isOnNavMesh && !navMeshAgent.isStopped)
            {
                navMeshAgent.ResetPath();
                _rigidbody.velocity = Vector3.zero;
            }
        }
    }
}