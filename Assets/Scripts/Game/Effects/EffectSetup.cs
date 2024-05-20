using System;
using UnityEngine;

namespace Effects
{
    [Serializable]
    public class EffectSetup
    {
        [SerializeField] private EffectTypeId effectTypeId;
        [SerializeField] private Effect effectPrefab;
        [SerializeField] private float value;

        public EffectTypeId TypeId => effectTypeId;
        public float Value => value;
        public Effect EffectPrefab => effectPrefab;
    }
}