using Entities.Interfaces;
using UnityEngine;

namespace Effects
{
    public abstract class Effect : MonoBehaviour, IEffect
    {
        protected EffectTypeId TypeId;
        protected IEffectable Target;
        protected float Value;

        public void Init(EffectTypeId typeId, IEffectable target, float value)
        {
            TypeId = typeId;
            Target = target;
            Value = value;
        }
        
        public abstract void Activate();
    }
}