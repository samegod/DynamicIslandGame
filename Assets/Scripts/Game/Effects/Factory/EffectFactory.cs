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
                case EffectTypeId.LightningBolts:
                    return CreateBolts(setup, target);
                    break;
            }

            throw new Exception("Could not create effect " + setup.TypeId);
        }

        private Effect CreateBolts(EffectSetup setup, IEffectable target)
        {
            Effect newEffect = new LightningBolts(setup.TypeId, target, setup.Value, setup.Visuals, 0, 10);
            newEffect.Activate();

            return newEffect;
        }

        private Effect CreateLightningStrike(EffectSetup setup, IEffectable target)
        {
            Effect newEffect = new LightningStrike(setup.TypeId, target, setup.Value, setup.Visuals);
            newEffect.Activate();

            return newEffect;
        }
    }
}