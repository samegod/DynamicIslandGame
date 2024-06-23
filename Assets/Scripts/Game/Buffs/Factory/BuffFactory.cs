using System;
using Buffs.Core;

namespace Buffs.Factory
{
    public class BuffFactory : IBuffFactory
    {
        public Buff CreateBuff(BuffSetup setup)
        {
            if (setup.TypeId == BuffTypeId.Poison)
            {
                return new Poison(setup.TypeId, setup.Value, setup.Duration, setup.Period);
            }

            if (setup.TypeId == BuffTypeId.Freeze)
            {
                return new Freeze(setup.TypeId, setup.Value, setup.Duration, setup.Period);
            }

            throw new Exception("Buff type Id is Unknown");
        }
    }
}