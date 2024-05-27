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
        protected EffectVisuals VisualsPrefab;

        public Effect(EffectTypeId typeId, IEffectable target, float value, EffectVisuals visualsPrefab)
        {
            TypeId = typeId;
            Target = target;
            Value = value;
            VisualsPrefab = visualsPrefab;
        }
        
        public abstract void Activate();

        protected EffectVisuals CreateVisuals()
        {
            return EffectVisualsPool.Instance.Pop(VisualsPrefab);
        }
    }
}