using System.Collections.Generic;
using Artifacts;
using Artifacts.Enums;

namespace ArtifactsOperator
{
    public interface IArtifactsOperatorService
    {
        void AddArtifact(ArtifactTypeId typeId);
        void OperateArtifact(Dictionary<ArtifactTypeId, int> currentArtifacts);
    }
}