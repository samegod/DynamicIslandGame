using System;
using System.Collections.Generic;
using Additions.Pool;
using Buffs.Interfaces;
using Sirenix.Utilities;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class Projectile : MonoBehaviourPoolObject, IProjectile
    {
        public event Action OnComplete;
        
        protected float Damage;
        protected readonly List<IEffectBuff> Effects = new List<IEffectBuff>();
        
        public override void Push()
        {
            ProjectilesPool.Instance.Push(this);
        }

        public virtual void SetDamage(float damage)
        {
            Damage = damage;
        }

        public virtual void SetEffects(List<IEffectBuff> effects)
        {
            if (effects.IsNullOrEmpty())
                return;
            
            Effects.AddRange(effects);
        }

        protected HitData CombineHitData()
        {
            var newData = new HitData
            {
                Effects = Effects,
                Damage = Damage
            };

            return newData;
        }
        
        protected void Complete()
        {
            OnComplete?.Invoke();
        }
    }
}
