using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemies.Combat
{
    public enum HitType
    { 
        Easy,
        Medium,
        Hard
    }
    
    [Serializable] 
    public struct AttackDescription
    {
        public HitType type;
        public int animationID;
        public float animationTime;
        public float impactTime;
        public float damageMultiplier;
        public float restTime;
    }

    [Serializable]
    public struct AttackPattern
    {
        public int id;
        public float restTime;
        public List<HitType> hits;
    }
    
    [CreateAssetMenu(fileName = "AttackSettings", menuName = "ScriptableObjects/AttackSettings")]
    public class AttackSettings : ScriptableObject
    {
        [SerializeField] private List<AttackDescription> attacks;
        [SerializeField] private bool useAttackPatterns;
        [SerializeField] private List<AttackPattern> patterns;
        
        public List<AttackDescription> Attacks => attacks;
        public bool UseAttackPatterns => useAttackPatterns;
        public List<AttackPattern> Patterns => patterns;

        public AttackDescription GetAttackDescription(HitType type)
        {
            return attacks.FirstOrDefault(x => x.type == type);
        }
    }
}
