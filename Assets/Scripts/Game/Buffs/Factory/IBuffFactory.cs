using Buffs.Core;

namespace Buffs.Factory
{
    public interface IBuffFactory
    {
        Buff CreateBuff(BuffSetup setup);
    }
}