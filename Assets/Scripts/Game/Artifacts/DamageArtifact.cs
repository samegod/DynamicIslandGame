using Artifacts.Core;
using Artifacts.Interfaces;
using Weapons.Core;

namespace Artifacts
{
    public class DamageArtifact : Artifact, IStat
    {
        private float _additionalDamage = 10;
        
        public void ApplyStats(Weapon weapon)
        {
            weapon.Stats.Damage += _additionalDamage;
        }
    }
}