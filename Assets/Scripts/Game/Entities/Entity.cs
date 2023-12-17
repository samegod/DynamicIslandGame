using Additions.Pool;
using Enemies.Core;
using Enemies.Pool;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(EntityMotion), typeof(EnemyHealth))]
    public abstract class Entity : MonoBehaviourPoolObject
    {
        [SerializeField, HideInInspector] protected EntityMotion entityMotion;
        [SerializeField, HideInInspector] protected EnemyHealth health;

        private void OnValidate()
        {
            entityMotion = GetComponent<EntityMotion>();
            health = GetComponent<EnemyHealth>();
        }

        protected virtual void OnEnable()
        {
            health.OnDeath += Die;
        }

        protected virtual void OnDisable()
        {
            health.OnDeath -= Die;
        }

        protected virtual void MoveTo(Vector3 position) => entityMotion.MoveTo(position);

        protected virtual void Reload()
        {
            health.Reload();
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
