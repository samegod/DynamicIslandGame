using System;
using Effects.Visuals;
using UnityEngine;

namespace Effects
{
    [Serializable]
    public class EffectSetup
    {
        [SerializeField] private EffectTypeId effectTypeId;
        [SerializeField] private EffectVisuals visuals;
        [SerializeField] private float value;

        public EffectTypeId TypeId => effectTypeId;
        public float Value => value;
        public EffectVisuals Visuals => visuals;
    }
}