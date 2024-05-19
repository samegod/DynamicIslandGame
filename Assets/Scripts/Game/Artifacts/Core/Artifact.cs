using System.Collections.Generic;
using Artifacts.Enums;
using Buffs;
using CharacterStats;
using Effects;

namespace Artifacts.Core
{
    public class Artifact : IArtifact
    {
        private readonly float _procChance;

        public Artifact(ArtifactBehaviour behaviour, List<ProcTrigger> procTriggers, float procChance, List<EffectSetup> effects, List<BuffSetup> buffs, List<StatSetup> stats)
        {
            Behaviour = behaviour;
            ProcTriggers = procTriggers;
            _procChance = procChance;
            Effects = effects;
            Buffs = buffs;
            Stats = stats;
        }

        public float GetProcChance() => _procChance;

        public ArtifactBehaviour Behaviour { get; }
        public List<ProcTrigger> ProcTriggers { get; }
        public List<EffectSetup> Effects { get; }
        public List<BuffSetup> Buffs { get; }
        public List<StatSetup> Stats { get; }
    }
}
