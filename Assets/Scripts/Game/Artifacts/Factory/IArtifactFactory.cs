using Artifacts.Core;

namespace Artifacts.Factory
{
    public interface IArtifactFactory
    {
        Artifact CreateArtifact(ArtifactTypeId typeId);
    }
}