using Artifacts.Core;

namespace CharacterInventory
{
    public interface IInventory
    {
        void AddArtifact(IArtifact newArtifact);
    }
}