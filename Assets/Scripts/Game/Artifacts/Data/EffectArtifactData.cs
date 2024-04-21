using Buffs.Core;
using UnityEngine;

namespace Artifacts.Data
{
    public class EffectArtifactData : ArtifactData
    {
        [SerializeField] private Buff buffPrefab;

        public Buff BuffPrefab => buffPrefab;
    }
}