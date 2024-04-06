using System;
using Entities;

namespace DynamicBlob.Core
{
    public class Shield : Entity
    {
        public event Action OnShieldBroken;
        
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
