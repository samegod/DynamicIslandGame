using System;
using System.Collections.Generic;
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
        public float animationTime;
        public float impactTime;
    }

    [Serializable]
    public struct AttackPattern
    {
        public int id;
        public List<HitType> hits;
    }
    
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/AttackSettings")]
    public abstract class AttackSettings : ScriptableObject
    {
        [SerializeField] private List<AttackDescription> attacks;
        [SerializeField] private bool useAttackPatterns;
        [SerializeField] private List<AttackPattern> patterns;
        
        public List<AttackDescription> Attacks => attacks;
        public bool UseAttackPatterns => useAttackPatterns;
        public List<AttackPattern> Patterns => patterns;
    }
}
