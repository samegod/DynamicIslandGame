using Entities.Interfaces;
using UnityEngine;

namespace Effects
{
    public class LightningStrike : Effect
    {
        [SerializeField] private ParticleSystem particles;

        public override void Activate()
        {
            transform.position = Target.GetPosition();
            
            particles.Play();
            if (Target is IHittable hittable)
            {
                hittable.TakeDamage(Value);
            }
        }
    }
}