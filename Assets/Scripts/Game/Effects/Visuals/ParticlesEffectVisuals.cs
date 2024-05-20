using UnityEngine;

namespace Effects.Visuals
{
    public class ParticlesEffectVisuals : EffectVisuals
    {
        [SerializeField] private ParticleSystem particles;

        public override void Activate()
        {
            particles.Play();
            base.Activate();
        }
    }
}