using System;
using UnityEngine;

namespace CharacterStats
{
    [Serializable]
    public class StatSetup
    {
        [SerializeField] private Stats stat;
        [SerializeField] private float value;

        public Stats Stat => stat;
        public float Value => value;
    }
}