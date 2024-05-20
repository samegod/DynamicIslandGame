using Effects.Visuals;
using Effects.Visuals.Pool;
using Entities.Interfaces;

namespace Effects
{
    public abstract class Effect : IEffect
    {
        protected EffectTypeId TypeId;
        protected IEffectable Target;
        protected float Value;
        protected EffectVisuals Visuals;

        public void Init(EffectTypeId typeId, IEffectable target, float value, EffectVisuals visuals)
        {
            TypeId = typeId;
            Target = target;
            Value = value;
            Visuals = visuals;
        }
        
        public abstract void Activate();

        protected EffectVisuals CreateVisuals()
        {
            return EffectVisualsPool.Instance.Pop(Visuals);
        }
    }
}