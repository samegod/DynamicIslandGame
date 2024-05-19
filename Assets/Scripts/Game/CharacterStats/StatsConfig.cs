using System;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterStats
{
    [CreateAssetMenu(menuName = "Configs/Stats", fileName = "StatsConfig", order = 0)]
    public class StatsConfig : ScriptableObject
    {
        [SerializeField] private List<StatData> _stats;

        public List<StatData> Stats => _stats;
    }

    [Serializable]
    public struct StatData
    {
        public Stats Stat;
        public float Value;
    }
}