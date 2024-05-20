using Entities.Interfaces;
using UnityEngine;

namespace Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        public Effect CreateEffect(EffectSetup setup, IEffectable target)
        {
            Effect newEffect = Object.Instantiate(setup.EffectPrefab);
            newEffect.Init(setup.TypeId, target, setup.Value);
            newEffect.Activate();

            return newEffect;
        }
    }
}