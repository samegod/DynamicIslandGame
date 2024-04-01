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

        public override void Update()
        {
            if (_attackDistance >= Enemy.GetRemainingDistance())
            {
                Enemy.StartFight();
            }
        }

        public override void FixedUpdate()
        {
            var size = Physics.OverlapSphereNonAlloc(Enemy.transform.position, _attackDistance, _colliders,
                LayerMask.GetMask("Player"));

            if (size == 1)
            {
                _colliders[0].GetComponent<IHitable>();
            }
        }

        public override void Stop()
        {
        }
    }
}