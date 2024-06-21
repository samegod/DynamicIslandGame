using System;
using Artifacts.Core;
using Entities.Interfaces;

namespace CharacterInventory
{
    public interface IInventoryOwner
    {
        event Action<IHittable> OnDamageTaken;
        event Action<IHittable> OnShoot;
        event Action<IHittable> OnImpact;
        
        void AddArtifact(Artifact newArtifact);
    }
}