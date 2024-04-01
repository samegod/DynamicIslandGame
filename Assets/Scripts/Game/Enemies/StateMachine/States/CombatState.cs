using Interfaces;
using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class CombatState : EnemyState
    {
        private float _hitDelay;
        private float _hitCooldown;
        private IHittable _target;
        
        public CombatState(float hitDelay, IHittable target)
        {
            _hitDelay = hitDelay;
            _target = target;
        }
        
        public override void Start() { }

        public override void Update()
        {
            if (_hitCooldown >= _hitDelay) {
                //Fight();
                Enemy.PerformAttack(_target);
                _hitCooldown = 0f;
            }

            _hitCooldown += Time.deltaTime;
        }

        public override void Stop() { }
    }
}