using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class AttackState : EnemyState
    {
        private Transform _targetPosition;
        private float _distanceToAttack;
        
        public AttackState(Transform targetPosition,float distanceToAttack)
        {
            _targetPosition = targetPosition;
            _distanceToAttack = distanceToAttack;
        }
        
        public override void Start()
        {
            Enemy.MoveTo(_targetPosition.position);
        }

        public override void Update()
        {
            if (_distanceToAttack >= Enemy.GetRemainingDistance()) {
                Enemy.StartFight();
            }
        }

        public override void Stop()
        {
        }
    }
}