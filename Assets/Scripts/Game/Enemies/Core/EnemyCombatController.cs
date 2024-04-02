using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct CombatSettings {
    public float damage;
}
public class EnemyCombatController : MonoBehaviour
{
    [SerializeField] protected CombatSettings settings;
    public void PerformAttack(IHittable target) 
    {
        target.TakeDamage(settings.damage);
    }
}
