using Buffs.Core;
using Buffs.Interfaces;
using CharacterStats;
using Effects;
using Enemies.Combat;
using Enemies.StateMachine;
using Enemies.StateMachine.States;
using Entities;
using Entities.Interfaces;
using UnityEngine;
using Weapons.Core;

namespace Enemies.Core
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyStateMachine), typeof(EnemyCombatController))]
    [RequireComponent(typeof(BuffsHolder))]
    public abstract class Enemy : Entity, IBuffable, IEffectable, IStatsProvider
    {
        [SerializeField] protected float deathTime = 1f;
        [SerializeField] protected float attackDistance = 5f;
        [SerializeField] protected EnemyStats stats;

        [SerializeField, HideInInspector] protected BuffsHolder buffsHolder;
        [SerializeField, HideInInspector] protected EnemyAnimator animator;
        [SerializeField, HideInInspector] protected EnemyStateMachine stateMachine;
        [SerializeField, HideInInspector] protected EnemyCombatController combatController;

        private bool _dead;

        public EnemyAnimator Animator => animator;

        private void OnValidate()
        {
            buffsHolder = GetComponent<BuffsHolder>();
            animator = GetComponent<EnemyAnimator>();
            stateMachine = GetComponent<EnemyStateMachine>();
            combatController = GetComponent<EnemyCombatController>();
        }

        protected override void Awake()
        {
            base.Awake();
            stateMachine.UpdateEnemy(this);
            
            combatController.Init(this, animator);
        }

        protected virtual void Start()
        {
            InitStats();
        }

        protected virtual void Update()
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
        
        public void AddBuff(IBuff buff)
        {
            Debug.Log("buff added");
            buffsHolder.AddBuff(buff);
        }

        public void AddEffect(IEffect effect)
        {
            throw new System.NotImplementedException();
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Transform GetTransform()
        {
            return transform;
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

        public override void TakeDamage(HitData hitData)
        {
            TakeDamage(hitData.Damage);
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

        public float GetStatValue(Stats stats)
        {
            throw new System.NotImplementedException();
        }
    }
}