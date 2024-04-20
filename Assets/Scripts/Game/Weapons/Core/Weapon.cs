using System;
using UnityEngine;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public event Action<Projectile> OnShoot;

        [SerializeField] protected WeaponInput weaponInput;
        [SerializeField] protected float damage;

        private ArtifactsManager _artifacts;
        
        public WeaponInput WeaponInput => weaponInput;

        public ArtifactsManager ArtifactsManager => _artifacts;

        protected virtual void Awake()
        {
            _artifacts = new ArtifactsManager();
        }

        public abstract void Shoot(ShotData data);

        protected void AddEffects(Projectile projectile)
        {
            projectile.SetEffects(_artifacts.GetEffects());
        }
        
        protected void ShootAction(Projectile projectile)
        {
            OnShoot?.Invoke(projectile);
        }
    }
}
