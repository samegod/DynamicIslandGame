using Enemies.Core;
using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class DeathState : EnemyState
    {
        private float _deathTime;
        private float _currentTimePassed = 0f;
        
        public DeathState(float deathTime)
        {
            _deathTime = deathTime;
        }
        
        public override void Start()
        {
            Animator.Die();
            Motion.Stop();
        }

        public override void Update()
        {
            _currentTimePassed += Time.deltaTime;

            if (_currentTimePassed >= _deathTime)
            {
                Enemy.Remove();
            }
        }

        public override void Stop()
        {
        }
    }
}
