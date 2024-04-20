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
        private Weapon _weapon;

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }
        
        public void AddBuff(IArtifact newArtifact)
        {
            switch (newArtifact)
            {
                case IStat stat:
                    _stats.Add(stat);
                    ApplyStats(stat);
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

            var randomNumber = Random.Range(0, 101);
            var effects = _effects.Where(effect => effect.GetProcChance() <= randomNumber).ToList();

            if (effects.Count == 0)
                return null;

            var outputEffects = new List<IEffectBuff>();
            foreach (var effect in effects)
            {
                outputEffects.Add(effect.CreateBuff());
            }

            return outputEffects;
        }

        private void ApplyStats(IStat stat)
        {
            stat.ApplyStats(_weapon);
        }
    }
}