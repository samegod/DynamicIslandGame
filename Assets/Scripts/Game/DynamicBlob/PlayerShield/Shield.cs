using System;
using Entities;
using UnityEngine;
using Weapons.Core;

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

        public override void TakeDamage(HitData hitData)
        {
            health.ReduceHealth(hitData.Damage);
        }

        protected override void Die()
        {
            OnShieldBroken?.Invoke();
        }
    }
}
