using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class FightState : EnemyState
    {
        private float _fightRate;
        private float _lastFightTime;
        
        public FightState(float fightRate)
        {
            _fightRate = fightRate;
        }
        
        public override void Start()
        {
           
        }

        public override void Update()
        {
            if (_lastFightTime >= _fightRate) {
                //Fight();
                _lastFightTime = 0f;
            }

            _lastFightTime += Time.deltaTime;
        }

        public override void Stop()
        {
        }

    }
}