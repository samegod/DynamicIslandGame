using UnityEngine;
using Weapons.Core;

namespace Weapons.RocketLauncherWeapon
{
    public class RocketLauncher : Weapon
    {
        [SerializeField] private RocketProjectile projectilePrefab;
        
        public override void Shoot(ShotData data)
        {
            RocketProjectile projectile = ProjectilesPool.Instance.Pop(projectilePrefab) as RocketProjectile;
            if (!projectile) return;
            
            projectile.transform.position = transform.position;
            projectile.Shoot(data.ShootPosition);
        }
    }
}
