using Additions.Pool;
using Enemies.Core;
using Enemies.Pool;
using Interfaces;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(EntityMotion), typeof(EntityHealth))]
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

        protected virtual void OnEnable()
        {
            Health.OnDeath += Die;
        }

        protected virtual void OnDisable()
        {
            Health.OnDeath -= Die;
        }

        public virtual void MoveTo(Vector3 position) => EntityMotion.MoveTo(position);

        public virtual void Stop()
        {
            EntityMotion.Stop();
        }

        protected virtual void Reload()
        {
            EntityMotion.Stop();
            Health.Reload();
        }
        
        public abstract void TakeDamage(float damage);
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
