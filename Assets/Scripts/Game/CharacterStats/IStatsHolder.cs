using System.Collections.Generic;

namespace CharacterStats
{
    public interface IStatsHolder
    {
        void SetDefaultStats(Dictionary<Stats, float> newStats);
        void AddStatAddition(Stats stat, float value);
        void AddStatMultiplier(Stats stat, float value);
        void ReduceStatAddition(Stats stat, float value);
        void ReduceStatMultiplier(Stats stat, float value);
        float GetStat(Stats stat);
    }
}