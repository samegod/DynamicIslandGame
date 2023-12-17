using System;
using Entities;
using UnityEngine;

namespace Enemies.Core
{
    [RequireComponent(typeof(EnemyAnimator))]
    public abstract class Enemy : Entity
    {
        [SerializeField] protected Transform targetPosition;
        [SerializeField, HideInInspector] protected EnemyAnimator animator;

        private void OnValidate()
        {
            animator = GetComponent<EnemyAnimator>();
        }

        private void Update()
        {
            animator.SetMotionSpeed(entityMotion.CurrentSpeed);
        }

        public void Init(Transform target)
        {
            targetPosition = target;
            MoveTo(targetPosition.position);
        }

        protected override void Die()
        {
            animator.Die();
            entityMotion.Stop();
            //Push();
        }

        public override void TakeDamage(float damage)
        {
            animator.TakeDamage();
            health.ReduceHealth(damage);
        }
    }
}
