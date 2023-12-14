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
        private Vector3 _targetPosition;
        
        private void Update()
        {
            if (_isFlying)
            {
                transform.LookAt(_targetPosition);
            }
        }

        public void Shoot(Vector3 finalPosition)
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
