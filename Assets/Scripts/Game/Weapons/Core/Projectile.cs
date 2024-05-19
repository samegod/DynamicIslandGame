using System;
using System.Collections.Generic;
using Additions.Pool;
using Buffs.Interfaces;
using Entities.Interfaces;
using Sirenix.Utilities;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class Projectile : MonoBehaviourPoolObject, IProjectile
    {
        public event Action<Projectile> OnComplete;
        public event Action<IHittable> OnDealDamage;
        
        protected float Damage;
        
        public override void Push()
        {
            ProjectilesPool.Instance.Push(this);
        }

        public virtual void SetDamage(float damage)
        {
            Damage = damage;
        }

        protected virtual void DealDamage(IHittable hittable)
        {
            OnDealDamage?.Invoke(hittable);
        }
        
        protected HitData CombineHitData()
        {
            var newData = new HitData
            {
                Damage = Damage
            };

            return newData;
        }
        
        protected void Complete()
        {
            OnComplete?.Invoke(this);
        }
    }
}
