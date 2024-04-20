using Artifacts.Interfaces;
using Buffs.Interfaces;

namespace Artifacts.Core
{
    public class EffectArtifact : Artifact, IEffect
    {
        private int _procChance = 20;
        
        public int GetProcChance()
        {
            return _procChance;
        }

        public IEffectBuff CreateBuff()
        {
            throw new System.NotImplementedException();
        }
    }
}