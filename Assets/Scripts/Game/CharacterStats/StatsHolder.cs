using System.Collections.Generic;
using UnityEngine;

namespace CharacterStats
{
    public class StatsHolder : IStatsHolder
    {
        private Dictionary<Stats, float> _baseStats = new Dictionary<Stats, float>();
        private Dictionary<Stats, float> _statAddition = new Dictionary<Stats, float>();
        private Dictionary<Stats, float> _statMultiplier = new Dictionary<Stats, float>();
        
        public void AddStatAddition(Stats stat, float value) => _statAddition[stat] += value;

        public void AddStatMultiplier(Stats stat, float value) => _statMultiplier[stat] += value;

        public void ReduceStatAddition(Stats stat, float value) => _statAddition[stat] -= value;

        public void ReduceStatMultiplier(Stats stat, float value) => _statMultiplier[stat] -= value;
        
        public void SetDefaultStats(Dictionary<Stats, float> newStats)
        {
            foreach (var newStat in newStats)
            {
                _baseStats[newStat.Key] = newStat.Value;
                _statAddition[newStat.Key] = 0;
                _statMultiplier[newStat.Key] = 1;
            }
        }

        public float GetStat(Stats stat)
        {
            float result = 0;

            if (_baseStats.ContainsKey(stat))
            {
                result += _baseStats[stat];
            }
            if (_statMultiplier.ContainsKey(stat))
            {
                result *= _statMultiplier[stat];
            }
            if (_statAddition.ContainsKey(stat))
            {
                result += _statAddition[stat];
            }

            result = Mathf.Clamp(result, 0, 99999);
            return result;
        }
    }
}