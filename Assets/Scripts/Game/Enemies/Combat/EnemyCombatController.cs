using System;
using System.Collections;
using Enemies.Core;
using Entities.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Combat
{
    public class EnemyCombatController : MonoBehaviour
    {
        [SerializeField] private AttackSettings attackSettings;

        private Enemy _thisEnemy;
        private EnemyAnimator _animator;
        private IHittable _target;
        private bool _combatIsGoing;
        private float _damage = 1;
        private Coroutine _combatCoroutine;

        public void Init(Enemy enemy, EnemyAnimator animator)
        {
            _thisEnemy = enemy;
            _animator = animator;
        }

        public void SetDamage(float damage)
        {
            _damage = damage;
        }

        public void StartCombat(IHittable target)
        {
            _combatIsGoing = true;
            _target = target;
            Debug.Log(_target == null);
            _combatCoroutine = StartCoroutine(Combat());
        }

        public void StopCombat()
        {
            _combatIsGoing = false;
        }

        private IEnumerator Combat()
        {
            while (_combatIsGoing)
            {
                if (attackSettings.UseAttackPatterns)
                {
                    int comboID = Random.Range(0, attackSettings.Patterns.Count);
                    yield return Combo(attackSettings.Patterns[comboID]);
                }
                else
                {
                    HitType type = (HitType)Random.Range(0, Enum.GetValues(typeof(HitType)).Length - 1);
                    yield return Attack(attackSettings.GetAttackDescription(type));
                }
            }
        }

        private IEnumerator Combo(AttackPattern pattern)
        {
            foreach (var hit in pattern.hits)
            {
                yield return Attack(attackSettings.GetAttackDescription(hit));
            }
            yield return new WaitForSeconds(pattern.restTime);
        }
        
        private IEnumerator Attack(AttackDescription description)
        {
            _animator.Attack(description.animationID);
            yield return new WaitForSeconds(description.impactTime);
            _target.TakeDamage(_damage * description.damageMultiplier);
            yield return new WaitForSeconds(description.animationTime - description.impactTime + description.restTime);
        }
    }
}