using System;
using UnityEngine;

namespace Enemies.Core
{
    public class EnemyHealth : MonoBehaviour
    {
        public event Action OnDeath;

        [SerializeField] private float maxHealth;
        
        private float _currentHealth;

        public float CurrentHealth => _currentHealth;

        public void Reload()
        {
            _currentHealth = maxHealth;
        }
        
        public void ReduceHealth(float healthToChange)
        {
            _currentHealth -= healthToChange;
            Debug.Log("Enemy " + gameObject.name + " took " + healthToChange + " damage!");
            
            if (_currentHealth <= 0)
            {
                Die();
                return;
            }

            if (_currentHealth> maxHealth) _currentHealth = maxHealth;
        }
        
        public void Die()
        {
            Debug.Log("Enemy " + gameObject.name + " died!");
            OnDeath?.Invoke();
        }
    }
}
