using Artifacts.Core;
using Artifacts.Interfaces;
using Buffs;
using Buffs.Interfaces;

namespace Artifacts
{
    public class PoisonArtifact : Artifact, IEffect
    {
        public int GetProcChance()
        {
            return 50;
        }

        public IBuff CreateBuff()
        {
            return new Poison();
        }
    }
}