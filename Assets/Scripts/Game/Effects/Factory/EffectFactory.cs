using System;
using Entities.Interfaces;

namespace Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        public Effect CreateEffect(EffectSetup setup, IEffectable target)
        {
            switch (setup.TypeId)
            {
                case EffectTypeId.LightningStrike:
                    return CreateLightningStrike(setup, target);
                    break;
            }

            throw new Exception("Could not create effect " + setup.TypeId);
        }

        private Effect CreateLightningStrike(EffectSetup setup, IEffectable target)
        {
            Effect newEffect = new LightningStrike();
            newEffect.Init(setup.TypeId, target, setup.Value, setup.Visuals);
            newEffect.Activate();

            return newEffect;
        }
    }
}