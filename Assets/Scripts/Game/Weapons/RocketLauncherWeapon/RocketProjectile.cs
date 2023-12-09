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
        
        public void Shoot(Vector2 finalPosition)
        {
            transform.DOMove(finalPosition, speed).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(Explode);
        }

        private void Explode()
        {
            Particles particles = ParticlesPool.Instance.Pop(explosionParticles);
            particles.transform.position = transform.position;
            particles.ThisParticles.Play();
            
            Push();
        }

        public override void Push()
        {
            ProjectilesPool.Instance.Push(this);
        }
    }
}
