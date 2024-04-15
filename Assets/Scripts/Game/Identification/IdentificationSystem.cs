using UnityEngine;

namespace Identification
{
    public enum TeamName
    {
        Player,
        Enemy,
        Neutral,
    }
    
    public static class IdentificationSystem 
    {
        public static bool CheckCanDamage(TeamName attackerTeam, TeamName targetTeam)
        {
            return RudeCheck(attackerTeam, targetTeam);
        }

        private static bool RudeCheck(TeamName attackerTeam, TeamName targetTeam)
        {
            if (attackerTeam != targetTeam)
            {
                return true;
            }

            return false;
        }
    }
}
