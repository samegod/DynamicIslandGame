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

        private WeaponStats _stats;
        private ArtifactsManager _artifactsManager;

        public WeaponInput WeaponInput => weaponInput;
        public ArtifactsManager ArtifactsManager => _artifactsManager;
        public WeaponStats Stats => _stats;

        protected virtual void Awake()
        {
            _stats = new WeaponStats();
            _artifactsManager = new ArtifactsManager();
            ArtifactsManager.SetWeapon(this);
        }

        private void Start()
        {
            InitStats();
        }

        public abstract void Shoot(ShotData data);

        protected void AddEffects(Projectile projectile)
        {
            projectile.SetEffects(ArtifactsManager.GetEffects());
        }
        
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
