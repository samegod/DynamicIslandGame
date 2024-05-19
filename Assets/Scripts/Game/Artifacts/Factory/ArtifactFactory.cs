using Artifacts.Core;
using Code.Gameplay.StaticData;

namespace Artifacts.Factory
{
    public class ArtifactFactory : IArtifactFactory
    {
        private readonly IStaticDataService _staticData;

        public ArtifactFactory(IStaticDataService staticData)
        {
            _staticData = staticData;
        }

        public Artifact CreateArtifact(ArtifactTypeId typeId)
        {
            ArtifactsConfig config = _staticData.GetArtifactConfig(typeId);
            
            return new Artifact(config.Behaviour, config.ProcTriggers, config.ProcChance, config.EffectSetups,
                config.BuffSetups, config.StatSetups);
        }
    }
}