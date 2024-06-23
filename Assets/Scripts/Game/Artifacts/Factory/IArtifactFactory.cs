using Artifacts.Core;
using Artifacts.Enums;

namespace Artifacts.Factory
{
    public interface IArtifactFactory
    {
        Artifact CreateArtifact(ArtifactTypeId typeId);
    }
}