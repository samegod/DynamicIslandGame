using System;
using UnityEngine;

namespace Enemies.Core
{
    public class EntityHealth : MonoBehaviour
    {
        public event Action OnHealthChanged;
        public event Action OnDeath;

        [SerializeField] private float maxHealth;
        
        private float _currentHealth;

        public float CurrentHealth => _currentHealth;
        public float MaxHealth => maxHealth;

        public void Reload()
        {
            _currentHealth = maxHealth;
        }

        public void SetMaxHealth(float newMaxHealth)
        {
            maxHealth = newMaxHealth;
        }
        
        public void ReduceHealth(float healthToChange)
        {
            _currentHealth -= healthToChange;
            
            if (_currentHealth <= 0)
            {
                Die();
                return;
            }

            if (_currentHealth> maxHealth) _currentHealth = maxHealth;
            
            OnHealthChanged?.Invoke();
        }
        
        public void Die()
        {
            OnDeath?.Invoke();
        }
    }
}
