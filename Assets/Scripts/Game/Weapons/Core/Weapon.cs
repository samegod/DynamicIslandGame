using System;
using UnityEngine;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public event Action<Projectile> OnShoot;

        [SerializeField] protected WeaponInput weaponInput;
        [SerializeField] private float attackDelay;
        [SerializeField] private float damage;
        [SerializeField] private float procChance;

        private WeaponStats _stats;

        public WeaponInput WeaponInput => weaponInput;
        public WeaponStats Stats => _stats;
        public float ProcChance => procChance;

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
            OnShoot?.Invoke(projectile);
        }

        private void InitStats()
        {
            _stats.Damage = damage;
            _stats.AttackDelay = attackDelay;
        }
    }
}
