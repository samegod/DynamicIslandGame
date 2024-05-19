using System.Collections.Generic;
using Artifacts.Enums;
using Buffs;
using CharacterStats;
using Effects;

namespace Artifacts.Core
{
    public interface IArtifact
    {
        float GetProcChance();
        ArtifactBehaviour Behaviour { get; }
        List<ProcTrigger> ProcTriggers { get; }
        List<EffectSetup> Effects { get; }
        List<BuffSetup> Buffs { get; }
        List<StatSetup> Stats { get; }
    }
}