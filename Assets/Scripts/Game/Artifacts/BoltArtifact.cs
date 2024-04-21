using Artifacts.Core;
using Artifacts.Interfaces;
using Buffs.Interfaces;

namespace Artifacts
{
    public class BoltArtifact : Artifact, IEffect
    {
        public int GetProcChance()
        {
            return 10;
        }

        //public IEffectBuff CreateBuff()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}