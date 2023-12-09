using Core;
using DG.Tweening;
using UnityEngine;
using Weapons.Core;

namespace Weapons.RocketLauncherWeapon
{
    public class RocketProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private Particles explosionParticles;

        private bool _isFlying;
        private Vector2 _targetPosition;
        
        private void Update()
        {
            if (_isFlying)
            {
                Vector2 direction = _targetPosition - (Vector2)transform.position;
                float newRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, newRotation - 90);
            }
        }

        public void Shoot(Vector2 finalPosition)
        {
            transform.DOMove(finalPosition, speed).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(Explode);
            _targetPosition = finalPosition;
            _isFlying = true;
        }

        private void Explode()
        {
            _isFlying = false;
            
            Particles particles = ParticlesPool.Instance.Pop(explosionParticles);
            particles.transform.position = transform.position;
            particles.ThisParticles.Play();
            
            Complete();
            Push();
        }
    }
}
