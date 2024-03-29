using System;
using Enemies.StateMachine;
using Enemies.StateMachine.States;
using Entities;
using Interfaces;
using UnityEngine;

namespace Enemies.Core
{
    [RequireComponent(typeof(EnemyAnimator))]
    public abstract class Enemy : Entity, IHittable
    {
        [SerializeField] protected float deathTime = 1f;
        [SerializeField] protected float distanceToAttack = 5f;
        [SerializeField] protected float fightRate = 1f;
        [SerializeField] protected EnemyStats stats;
        [SerializeField, HideInInspector] protected EnemyAnimator animator;
        [SerializeField, HideInInspector] protected EnemyStateMachine stateMachine;

        private bool _dead;
        
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

        private void Start()
        {
            InitStats();
        }

        private void Update()
        {
            Animator.SetMotionSpeed(EntityMotion.CurrentSpeed);
        }

        public void Attack(Transform target)
        {
            stateMachine.StartNewState(new AttackState(target, distanceToAttack));
        }

        public void StartFight()
        {
            stateMachine.StartNewState(new FightState(fightRate));
        }

        protected override void Die()
        {
            stateMachine.StartNewState(new DeathState(deathTime));
            _dead = true;
        }

        public override void TakeDamage(float damage)
        {
            if (_dead)
                return;
            
            Animator.TakeDamage();
            Health.ReduceHealth(damage);
        }

        public void Remove()
        {
            stateMachine.StopStates();
            _dead = false;
            Push();
        }

        private void InitStats()
        {
            if (!stats)
                return;
            
            Health.SetMaxHealth(stats.Health);
            EntityMotion.SetSpeed(stats.Speed);
        }
    }
}