using System;
using Interfaces;
using UnityEngine;

namespace Enemies.Combat
{
    public class EnemyCombatController : MonoBehaviour
    {
        [SerializeField] private AttackSettings attackSettings;

        private IHittable _target;
        
        public void PerformAttack(IHittable target) 
        {
        }

        public void StartCombat(IHittable target)
        {
            _target = target;
        }
    }
}