namespace CharacterStats
{
    public interface IStatsProvider
    {
        float GetStatValue(Stats stats);
        void SetStatMultiplier(Stats stats, float value);
        void SetStatAddition(Stats stats, float value);
    }
}