using Enemies.Core;
using UnityEngine;

namespace Enemies.StateMachine
{
    public class EnemyStateMachine : MonoBehaviour
    {
        private Enemy _currentEnemy;
        private EnemyState _currentState;

        public void UpdateEnemy(Enemy enemy)
        {
            _currentEnemy = enemy;
        }
        
        public void StartNewState(EnemyState newState)
        {
            if (_currentState != null)
            {
                _currentState.Stop();
            }

            _currentState = newState;
            _currentState.SetDefaultComponents(_currentEnemy, _currentEnemy.Animator, _currentEnemy.EntityMotion);
            _currentState.Start();
        }

        private void Update()
        {
            _currentState?.Update();
        }

        private void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }

        public void StopStates()
        {
            if (_currentState != null)
            {
                _currentState.Stop();
                _currentState = null;
            }
        }
    }
}
