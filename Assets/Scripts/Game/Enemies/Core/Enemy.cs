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
        [SerializeField] protected float attackDistance = 5f;
        [SerializeField] protected float hitDelay = 1f;
        [SerializeField] protected LayerMask blobLayerMask;
        [SerializeField] protected EnemyStats stats;
        [SerializeField, HideInInspector] protected EnemyAnimator animator;
        [SerializeField, HideInInspector] protected EnemyStateMachine stateMachine;

        public EnemyAnimator Animator => animator;

        private int maxColliders = 1;

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

        private void FixedUpdate() {
            if (IsBlobInAttack()) {
                StartFight();
            }
        }

        public void Attack(Transform target)
        {
            stateMachine.StartNewState(new AttackState(target));
        }

        public void StartFight()
        {
            stateMachine.StartNewState(new CombatState(hitDelay));
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

        private void InitStats()
        {
            if (!stats)
                return;
            
            Health.SetMaxHealth(stats.Health);
            EntityMotion.SetSpeed(stats.Speed);
        }

        private bool IsBlobInAttack() {
            Collider[] hitColliders = new Collider[maxColliders];
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, attackDistance, hitColliders, blobLayerMask);
            return numColliders > 0;
        }

    }
}