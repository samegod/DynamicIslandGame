using Enemies.Core;
using Interfaces;
using System;
using UnityEngine;

namespace Enemies.Cactus
{
    public class Cactus : Enemy
    {
        [SerializeField] private float damage;
        public override void PerformAttack(IHittable target) {
            Animator.Attack();
            target.TakeDamage(damage);
        }
    }
}
