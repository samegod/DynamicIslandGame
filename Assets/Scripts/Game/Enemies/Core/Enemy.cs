using Enemies.StateMachine;
using Enemies.StateMachine.States;
using Entities;
using UnityEngine;

namespace Enemies.Core
{
    [RequireComponent(typeof(EnemyAnimator))]
    public abstract class Enemy : Entity
    {
        [SerializeField] protected float deathTime = 1f;
        [SerializeField] protected EnemyStats stats;
        [SerializeField, HideInInspector] protected EnemyAnimator animator;
        [SerializeField, HideInInspector] protected EnemyStateMachine stateMachine;

        public EnemyAnimator Animator => animator;

        private void OnValidate()
        {
            animator = GetComponent<EnemyAnimator>();
            stateMachine = GetComponent<EnemyStateMachine>();
        }

        private void Awake()
        {
            stateMachine.UpdateEnemy(this);
        }

        private void Update()
        {
            Animator.SetMotionSpeed(EntityMotion.CurrentSpeed);
        }

        public void Attack(Transform target)
        {
            stateMachine.StartNewState(new AttackState(target));
        }

        protected override void Die()
        {
            stateMachine.StartNewState(new DeathState(deathTime));
        }

        public override void TakeDamage(float damage)
        {
            Animator.TakeDamage();
            Health.ReduceHealth(damage);
        }

        public void Remove()
        {
            stateMachine.StopStates();
            Push();
        }
    }
}