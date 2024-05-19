using System.Collections.Generic;
using Artifacts.Core;
using Entities.Interfaces;

namespace CharacterInventory.ArtifactsProc
{
    public interface IArtifactsProcService
    {
        void ProcessProc(List<IArtifact> artifacts, IHittable target);
    }
}