using System;
using UnityEngine;

namespace Effects.Visuals
{
    public class ParticlesEffectVisuals : EffectVisuals
    {
        [SerializeField] private ParticleSystem particles;

        public override void Activate(Action callback = null)
        {
            particles.Play();
            base.Activate(callback);
        }
    }
}