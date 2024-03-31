using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class CombatState : EnemyState
    {
        private float _hitDelay;
        private float _hitCooldown;
        
        public CombatState(float hitDelay)
        {
            _hitDelay = hitDelay;
        }
        
        public override void Start() { }

        public override void Update()
        {
            if (_hitCooldown >= _hitDelay) {
                //Fight();
                _hitCooldown = 0f;
            }

            _hitCooldown += Time.deltaTime;
        }

        public override void Stop() { }
    }
}