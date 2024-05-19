using System.Collections.Generic;
using Additionals.Extensions;
using Artifacts.Core;
using Artifacts.Enums;
using Buffs.Factory;
using CharacterInventory.ArtifactsProc;
using Effects.Factory;
using Entities.Interfaces;

namespace CharacterInventory
{
    public class Inventory : IInventory
    {
        private readonly IArtifactsProcService _procService;
        private readonly List<IArtifact> _allArtifacts = new List<IArtifact>();
        private readonly List<IArtifact> _impactProcables = new List<IArtifact>();
        private readonly List<IArtifact> _shootProcables = new List<IArtifact>();
        private readonly List<IArtifact> _damageProcables = new List<IArtifact>();
        private readonly List<IArtifact> _stats = new List<IArtifact>();

        private readonly IBuffFactory _buffFactory;
        private readonly IEffectFactory _effectFactory;

        public Inventory(IInventoryOwner inventoryOwner, IArtifactsProcService procService)
        {
            _procService = procService;
            
            inventoryOwner.OnDamageTaken += ProcDamageTaken;
            inventoryOwner.OnShoot += ProcShoot;
            inventoryOwner.OnImpact += ProcImpact;
        }
        
        public void AddArtifact(IArtifact newArtifact)
        {
            _allArtifacts.Add(newArtifact);

            if (newArtifact.Behaviour.HasFlag(ArtifactBehaviour.Proc))
                AddProcableArtifact(newArtifact);
            if (newArtifact.Behaviour.HasFlag(ArtifactBehaviour.Stat))
                _stats.Add(newArtifact);
        }

        private void AddProcableArtifact(IArtifact procable)
        {
            foreach (var procTrigger in procable.ProcTriggers)
            {
                switch (procTrigger)
                {
                    case ProcTrigger.Impact:
                        _impactProcables.Add(procable);
                        break;
                    case ProcTrigger.Shoot:
                        _shootProcables.Add(procable);
                        break;
                    case ProcTrigger.Hit:
                        _damageProcables.Add(procable);
                        break;
                }
            }
        }

        private void ProcDamageTaken(IHittable target)
        {
            if (_damageProcables.IsNullOrEmpty())
                return;
            
            _procService.ProcessProc(_damageProcables, target);
        }
        
        private void ProcShoot(IHittable target)
        {
            if (_shootProcables.IsNullOrEmpty())
                return;
            
            _procService.ProcessProc(_shootProcables, target);
        }

        private void ProcImpact(IHittable target)
        {
            if (_impactProcables.IsNullOrEmpty())
                return;
            
            _procService.ProcessProc(_impactProcables, target);
        }
    }
}