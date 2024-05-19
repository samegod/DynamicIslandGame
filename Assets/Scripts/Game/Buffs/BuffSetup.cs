using System;
using UnityEngine;

namespace Buffs
{
    [Serializable]
    public class BuffSetup
    {
        [SerializeField] private BuffTypeId typeId;
        [SerializeField] private float value;
        [SerializeField] private float duration;
        [SerializeField] private float period;

        public BuffTypeId TypeId => typeId;
        public float Value => value;
        public float Duration => duration;
        public float Period => period;
    }
}