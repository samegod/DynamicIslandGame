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
                return new Poison(setup.Value, setup.Duration, setup.Period);
            }

            throw new Exception("Buff type Id is Unknown");
        }
    }
}