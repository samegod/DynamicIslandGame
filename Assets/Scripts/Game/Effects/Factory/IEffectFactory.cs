using Entities.Interfaces;

namespace Effects.Factory
{
    public interface IEffectFactory
    {
        Effect CreateEffect(EffectSetup setup, IEffectable target);
    }
}