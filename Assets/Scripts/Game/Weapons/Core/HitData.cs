using System.Collections.Generic;
using Buffs.Interfaces;

namespace Weapons.Core
{
    public class HitData
    {
        public float Damage;
        public List<IEffectBuff> Effects;
    }
}
