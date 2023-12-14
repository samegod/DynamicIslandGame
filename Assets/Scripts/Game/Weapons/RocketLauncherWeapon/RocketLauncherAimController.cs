using UnityEngine;
using Weapons.Core;
using Weapons.RocketLauncherWeapon.Aim;

namespace Weapons.RocketLauncherWeapon
{
    public class RocketLauncherAimController : AimController
    {
        private readonly RocketAim _aimPrefab;
        private Transform _inputPlane;
        private RocketAim _currentAim;
        
        public RocketLauncherAimController(RocketLauncher weapon, RocketAim aimPrefab, Transform inputPlane) : base(weapon)
        {
            _aimPrefab = aimPrefab;
            _inputPlane = inputPlane;
            
            weapon.OnShoot += ApplyAim;
        }

        protected override void MouseDown(ShotData shotData)
        {
            _currentAim = AimsPool.Instance.Pop(_aimPrefab) as RocketAim;
            if (!_currentAim) return;

            _currentAim.transform.parent = _inputPlane;
            _currentAim.transform.localEulerAngles = Vector3.zero;
            _currentAim.transform.position = shotData.ShootPosition2D;
            
            base.MouseDown(shotData);
        }

        protected override void MouseHold(ShotData shotData)
        {
            if (!_currentAim) return;

            _currentAim.transform.position = shotData.ShootPosition2D;
            
            base.MouseHold(shotData);
        }

        private void ApplyAim(Projectile projectile)
        {
            if (!_currentAim) return;

            _currentAim.Apply();
            _currentAim.TrackProjectile(projectile);
            _currentAim = null;
        }
    }
}
