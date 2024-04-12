using System;
using Entities;
using UnityEngine;

namespace DynamicBlob.PlayerShield
{
    public class Shield : Entity
    {
        public event Action OnShieldBroken;

        [SerializeField] private float maxHealth;
        
        private void Awake()
        {
            health.SetMaxHealth(maxHealth);
            health.Reload();
        }

        public override void TakeDamage(float damage)
        {
            health.ReduceHealth(damage);
        }
 
        protected override void Die()
        {
            OnShieldBroken?.Invoke();
        }
    }
}
