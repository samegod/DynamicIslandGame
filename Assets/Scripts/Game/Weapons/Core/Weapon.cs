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
        
        public WeaponInput WeaponInput => weaponInput;

        public abstract void Shoot(ShotData data);

        protected void ShootAction(Projectile projectile)
        {
            OnShoot?.Invoke(projectile);
        }
    }
}
