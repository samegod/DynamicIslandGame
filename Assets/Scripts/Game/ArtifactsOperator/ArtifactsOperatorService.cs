using System.Collections.Generic;
using Artifacts;
using Artifacts.Enums;
using Code.Gameplay.StaticData;

namespace ArtifactsOperator
{
    public class ArtifactsOperatorService : IArtifactsOperatorService
    {
        private readonly IStaticDataService _staticData;

        public ArtifactsOperatorService(IStaticDataService staticData)
        {
            _staticData = staticData;
        }

        public void AddArtifact(ArtifactTypeId typeId)
        {
            _staticData.GetArtifactConfig(typeId);
        }

        public void RemoveArtifact(ArtifactTypeId typeId)
        {
            
        }

        public void OperateArtifact(Dictionary<ArtifactTypeId, int> currentArtifacts)
        {
            foreach (var artifact in currentArtifacts)
            {
                
            }
        }
    }
}