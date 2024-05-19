using System.Collections.Generic;
using Artifacts.Enums;
using Buffs;
using CharacterStats;
using Effects;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Artifacts
{
    [CreateAssetMenu(menuName = "Configs/Artifact", fileName = "ArtifactsConfig")]
    public class ArtifactsConfig : ScriptableObject
    {
        [SerializeField] private ArtifactTypeId artifactTypeId;
        [SerializeField] private ArtifactBehaviour behaviour;
        [SerializeField] private List<ProcTrigger> procTriggers;
        [SerializeField, Range(0, 1f)] private float procChance;
        [SerializeField] private List<EffectSetup> effectSetups;
        [SerializeField] private List<BuffSetup> buffSetups;
        [SerializeField] private List<StatSetup> statSetups;

        public ArtifactBehaviour Behaviour => behaviour;
        public List<ProcTrigger> ProcTriggers => procTriggers;
        public ArtifactTypeId TypeId => artifactTypeId;
        public List<EffectSetup> EffectSetups => effectSetups;
        public List<StatSetup> StatSetups => statSetups;
        public List<BuffSetup> BuffSetups => buffSetups;
        public float ProcChance => procChance;
    }
}