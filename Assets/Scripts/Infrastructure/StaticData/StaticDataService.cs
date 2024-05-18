using System;
using System.Collections.Generic;
using System.Linq;
using Artifacts;
using Code.Gameplay.StaticData;
using UnityEngine;

namespace Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<ArtifactTypeId, ArtifactsConfig> _artifactById;

        public void LoadAll()
        {
            LoadArtifacts();
        }

        public ArtifactsConfig GetArtifactConfig(ArtifactTypeId artifactTypeId)
        {
            if (_artifactById.TryGetValue(artifactTypeId, out var config))
                return config;

            throw new Exception($"Ability config for {artifactTypeId} was not found");
        }

        private void LoadArtifacts()
        {
            _artifactById = Resources
                .LoadAll<ArtifactsConfig>("Configs/Artifacts")
                .ToDictionary(x => x.TypeId, x => x);
        }
    }
}