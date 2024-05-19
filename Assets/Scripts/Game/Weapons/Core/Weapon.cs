using System;
using Entities.Interfaces;
using UnityEngine;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public event Action<Projectile> OnShoot;
        public event Action<IHittable> OnImpact;

        [SerializeField] protected WeaponInput weaponInput;
        [SerializeField] private float attackDelay;
        [SerializeField] private float damage;

        private WeaponStats _stats;

        public WeaponInput WeaponInput => weaponInput;
        public WeaponStats Stats => _stats;

        protected virtual void Awake()
        {
            _stats = new WeaponStats();
        }

        private void Start()
        {
            InitStats();
        }

        public abstract void Shoot(ShotData data);
        
        protected void ShootAction(Projectile projectile)
        {
            projectile.OnComplete += ProjectileCompleted;
            projectile.OnDealDamage += Impact;
            
            OnShoot?.Invoke(projectile);
        }

        protected void Impact(IHittable target)
        {
            OnImpact?.Invoke(target);
        }

        protected void ProjectileCompleted(Projectile projectile)
        {
            projectile.OnDealDamage -= Impact;
            projectile.OnComplete -= ProjectileCompleted;
        }

        private void InitStats()
        {
            _stats.Damage = damage;
            _stats.AttackDelay = attackDelay;
        }
    }
}
