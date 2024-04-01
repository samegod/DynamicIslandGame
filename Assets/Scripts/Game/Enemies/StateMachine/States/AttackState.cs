using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class AttackState : EnemyState
    {
        private readonly Transform _targetPosition;
        
        public AttackState(Transform targetPosition)
        {
            _targetPosition = targetPosition;
        }
        
        public override void Start()
        {
            Enemy.MoveTo(_targetPosition.position);
        }

        public override void Update()
        {
        }

        public override void Stop()
        {
        }
    }
}