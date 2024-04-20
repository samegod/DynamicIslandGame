using System.Collections.Generic;
using System.Linq;
using Artifacts.Interfaces;
using Buffs.Interfaces;
using UnityEngine;

namespace Weapons.Core
{
    public class ArtifactsManager
    {
        private List<IStat> _stats = new List<IStat>();
        private List<IEffect> _effects = new List<IEffect>();
        
        public void AddBuff(IArtifact newArtifact)
        {
            switch (newArtifact)
            {
                case IStat stat:
                    _stats.Add(stat);
                    break;
                case IEffect effect:
                    _effects.Add(effect);
                    break;
            }
        }

        public List<IEffectBuff> GetEffects()
        {
            if (_effects.Count == 0)
                return null;

            Debug.Log("rand");
            var randomNumber = Random.Range(0, 101);
            var effects = _effects.Where(effect => effect.GetProcChance() <= randomNumber).ToList();

            Debug.Log("randfini");
            if (effects.Count == 0)
                return null;

            Debug.Log("out");
            var outputEffects = new List<IEffectBuff>();
            foreach (var effect in effects)
            {
                outputEffects.Add(effect.CreateBuff());
            }

            Debug.Log("outfini" + outputEffects.Count);
            return outputEffects;
        }
    }
}