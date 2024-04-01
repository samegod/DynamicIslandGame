using Interfaces;
using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class AttackState : EnemyState
    {
        private readonly Transform _targetPosition;
        private readonly float _attackDistance;

        private readonly Collider[] _colliders = new Collider[5];

        public AttackState(Transform targetPosition, float attackDistance)
        {
            _targetPosition = targetPosition;
            _attackDistance = attackDistance;
        }

        public override void Start()
        {
            Enemy.MoveTo(_targetPosition.position);
        }

        public override void Update() { }

        public override void FixedUpdate()
        {
            var size = Physics.OverlapSphereNonAlloc(Enemy.transform.position, _attackDistance, _colliders,
                LayerMask.GetMask("Player"));

            if (size == 0)
                return;

            foreach (var collider in _colliders)
            {
                IHittable hittable = collider.GetComponent<IHittable>();

                if (hittable != null)
                {
                    Enemy.StartFight(hittable);
                }
            }
        }

        public override void Stop()
        {
        }
    }
}