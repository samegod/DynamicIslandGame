using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatType
{ 
    Easy,
    Medium,
    Hard
}
[System.Serializable]
public struct CombatSettings {
    public float damage;
    public CombatType type;
    public int variationCount;
}
public class EnemyCombatController : MonoBehaviour
{
    [SerializeField] protected CombatSettings settings;
    public void PerformAttack(IHittable target) 
    {
        target.TakeDamage(settings.damage);
    }
}
