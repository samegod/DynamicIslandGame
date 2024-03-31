using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class AttackState : EnemyState
    {
        private readonly Transform _targetPosition;
        private readonly float _attackDistance;
        
        public AttackState(Transform targetPosition,float attackDistance)
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
            if (_attackDistance >= Enemy.GetRemainingDistance()) {
                Enemy.StartFight();
            }
        }

        public override void Stop()
        {
        }
    }
}