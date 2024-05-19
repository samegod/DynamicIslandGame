using UnityEngine;
using Weapons.Core;
using Weapons.RocketLauncherWeapon.Aim;

namespace Weapons.RocketLauncherWeapon
{
    public class RocketLauncher : Weapon
    {
        [SerializeField] private Transform inputPlane;
        [SerializeField] private RocketProjectile projectilePrefab;
        [SerializeField] private RocketAim aimPrefab;

        private RocketLauncherAimController _aimController;

        protected override void Awake()
        {
            base.Awake();
            _aimController = new RocketLauncherAimController(this, aimPrefab, inputPlane);
        }

        private void OnEnable()
        {
            weaponInput.OnMouseUp += Shoot;
        }

        private void OnDisable()
        {
            weaponInput.OnMouseUp -= Shoot;
        }

        public override void Shoot(ShotData data)
        {
            RocketProjectile projectile = ProjectilesPool.Instance.Pop(projectilePrefab) as RocketProjectile;
            if (!projectile) return;
            
            projectile.transform.position = transform.position;
            projectile.SetDamage(Stats.Damage);
            projectile.Shoot(data.ShootPosition);
            
            ShootAction(projectile);
        }
    }
}
