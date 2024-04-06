using Enemies.Combat;
using Enemies.StateMachine;
using Enemies.StateMachine.States;
using Entities;
using Interfaces;
using UnityEngine;

namespace Enemies.Core
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyStateMachine), typeof(EnemyCombatController))]
    public abstract class Enemy : Entity, IHittable
    {
        [SerializeField] protected float deathTime = 1f;
        [SerializeField] protected float attackDistance = 5f;
        [SerializeField] protected EnemyStats stats;
        
        [SerializeField, HideInInspector] protected EnemyAnimator animator;
        [SerializeField, HideInInspector] protected EnemyStateMachine stateMachine;
        [SerializeField, HideInInspector] protected EnemyCombatController combatController;

        private bool _dead;

        public EnemyAnimator Animator => animator;

        private void OnValidate()
        {
            animator = GetComponent<EnemyAnimator>();
            stateMachine = GetComponent<EnemyStateMachine>();
            combatController = GetComponent<EnemyCombatController>();
        }

        private void Awake()
        {
            stateMachine.UpdateEnemy(this);
            
            combatController.Init(this, animator);
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
            stateMachine.StartNewState(new AttackState(target, attackDistance));
        }

        public void StartFight(IHittable target)
        {
            stateMachine.StartNewState(new CombatState(combatController, target));
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

            combatController.SetDamage(stats.Damage);
            Health.SetMaxHealth(stats.Health);
            EntityMotion.SetSpeed(stats.Speed);
        }
    }
}