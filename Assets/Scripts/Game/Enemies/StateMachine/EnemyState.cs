using Enemies.Core;
using Entities;

namespace Enemies.StateMachine
{
    public abstract class EnemyState
    {
        protected Enemy Enemy;
        protected EnemyAnimator Animator;
        protected EntityMotion Motion;

        public abstract void Start();
        public abstract void Update();
        public abstract void Stop();

        public virtual void FixedUpdate() {}
        
        public void SetDefaultComponents(Enemy enemy, EnemyAnimator animator, EntityMotion motion)
        {
            Enemy = enemy;
            Animator = animator;
            Motion = motion;
        }
    }
}