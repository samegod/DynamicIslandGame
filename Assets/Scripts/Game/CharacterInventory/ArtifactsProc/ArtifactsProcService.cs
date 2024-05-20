using System.Collections.Generic;
using Additionals.Extensions;
using Artifacts.Core;
using Buffs.Factory;
using Effects.Factory;
using Entities.Interfaces;
using UnityEngine;

namespace CharacterInventory.ArtifactsProc
{
    public class ArtifactsProcService : IArtifactsProcService
    {
        private readonly IBuffFactory _buffFactory;
        private readonly IEffectFactory _effectFactory;

        public ArtifactsProcService(IBuffFactory buffFactory, IEffectFactory effectFactory)
        {
            _buffFactory = buffFactory;
            _effectFactory = effectFactory;
        }
        
        public void ProcessProc(List<IArtifact> artifacts, IHittable target)
        {
            var artifactsToProcess = ProcArtifacts(artifacts);

            if (artifactsToProcess.IsNullOrEmpty())
                return;

            foreach (var artifact in artifactsToProcess)
            {
                if (target is IBuffable buffable)
                {
                    foreach (var buffSetup in artifact.Buffs)
                    {
                        var buff = _buffFactory.CreateBuff(buffSetup);
                        buffable.AddBuff(buff);
                    }
                }
                
                if (target is IEffectable effectable)
                {
                    foreach (var effectSetup in artifact.Effects)
                    {
                        _effectFactory.CreateEffect(effectSetup, effectable);
                    }
                }
            }
        }
        
        private List<IArtifact> ProcArtifacts(List<IArtifact> artifacts)
        {
            List<IArtifact> procked = new List<IArtifact>();

            float chance = Random.Range(0, 1f);

            foreach (var artifact in artifacts)
            {
                if (artifact.GetProcChance() >= chance)
                {
                    procked.Add(artifact);
                }
            }

            return procked;
        }
    }
}