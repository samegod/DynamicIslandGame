using Buffs.Interfaces;

namespace Artifacts.Interfaces
{
    public interface IEffect : IArtifact
    {
        int GetProcChance();
        //IEffectBuff CreateBuff();
    }
}