using UnityEngine;

namespace Enemies.Core
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private float _maxMotionSpeed = 1f;
        
        private readonly int _takeDamageHash = Animator.StringToHash("TakeDamage");
        private readonly int _deathHash = Animator.StringToHash("Death");
        private readonly int _motionSpeedHash = Animator.StringToHash("MotionSpeed");

        public void SetMaxMotionSpeed(float maxMotionSpeed)
        {
            _maxMotionSpeed = maxMotionSpeed;
        }
        
        public void TakeDamage()
        {
            animator.SetTrigger(_takeDamageHash);
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
