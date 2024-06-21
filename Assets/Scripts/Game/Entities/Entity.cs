using System.Collections.Generic;
using Additions.Pool;
using CharacterStats;
using Enemies.Core;
using Enemies.Pool;
using Entities.Interfaces;
using UnityEngine;
using Weapons.Core;

namespace Entities
{
    [RequireComponent(typeof(EntityHealth))]
    public abstract class Entity : MonoBehaviourPoolObject, IHittable
    {
        [SerializeField, HideInInspector] protected EntityMotion entityMotion;
        [SerializeField, HideInInspector] protected EntityHealth health;

        public EntityMotion EntityMotion => entityMotion;
        public EntityHealth Health => health;

        private void OnValidate()
        {
            entityMotion = GetComponent<EntityMotion>();
            health = GetComponent<EntityHealth>();
        }

        protected virtual void Awake()
        {
        }

        protected virtual void OnEnable()
        {
            Health.OnDeath += Die;
        }
        
        protected virtual void OnDisable()
        {
            Health.OnDeath -= Die;
        }

        public void SetBaseStats(Dictionary<Stats, float> newStats)
        {
        }

        public virtual void MoveTo(Vector3 position)
        {
            if (EntityMotion)
                EntityMotion.MoveTo(position);
        }

        public virtual void Stop()
        {
            EntityMotion.Stop();
        }

        protected virtual void Reload()
        {
            if (EntityMotion)
                EntityMotion.Stop();
            Health.Reload();
        }

        public abstract void TakeDamage(float damage);
        public abstract void TakeDamage(HitData hitData);

        protected abstract void Die();

        public override void OnPop()
        {
            Reload();
            base.OnPop();
        }

        public override void Push()
        {
            EntitiesPool.Instance.Push(this);
        }
    }
}