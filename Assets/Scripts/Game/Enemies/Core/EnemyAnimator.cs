using UnityEngine;

namespace Enemies.Core
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        protected float _maxMotionSpeed = 1f;

        protected readonly int _takeDamageHash = Animator.StringToHash("TakeDamage");
        protected readonly int _attackHash = Animator.StringToHash("Attack");
        protected readonly int _deathHash = Animator.StringToHash("Death");
        protected readonly int _motionSpeedHash = Animator.StringToHash("MotionSpeed");
        protected readonly int _attackIdHash = Animator.StringToHash("AttackID");

        public void SetMaxMotionSpeed(float maxMotionSpeed)
        {
            _maxMotionSpeed = maxMotionSpeed;
        }
        
        public void TakeDamage()
        {
            animator.SetTrigger(_takeDamageHash);
        }
        public void Attack(int id) {
            animator.SetInteger(_attackIdHash, id);
            animator.SetTrigger(_attackHash);
        }

        public void Die()
        {
            animator.SetBool(_deathHash, true);
        }

        public void SetMotionSpeed(float currentSpeed)
        {
            animator.SetFloat(_motionSpeedHash, currentSpeed / _maxMotionSpeed);
        }
    }
}
