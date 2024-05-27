using Effects.Visuals;
using Entities.Interfaces;

namespace Effects
{
    public class LightningStrike : Effect
    {
        public LightningStrike(EffectTypeId typeId, IEffectable target, float value, EffectVisuals visualsPrefab) : base(typeId, target, value, visualsPrefab)
        {
        }
        
        public override void Activate()
        {
            EffectVisuals visuals = CreateVisuals();
            visuals.SetPosition(Target.GetPosition());
            visuals.Activate();
            
            if (Target is IHittable hittable)
            {
                hittable.TakeDamage(Value);
            }
        }

    }
}