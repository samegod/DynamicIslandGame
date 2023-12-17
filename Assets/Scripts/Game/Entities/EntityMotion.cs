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

        public void MoveTo(Vector3 targetPosition)
        {
            navMeshAgent.SetDestination(targetPosition);
        }

        public void Stop()
        {
            navMeshAgent.ResetPath();
            _rigidbody.velocity = Vector3.zero;
        }
    }
}