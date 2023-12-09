using Weapons.Core;
using Weapons.RocketLauncherWeapon.Aim;

namespace Weapons.RocketLauncherWeapon
{
    public class RocketLauncherAimController : AimController
    {
        private readonly RocketAim _aimPrefab;
        private RocketAim _currentAim;
        
        public RocketLauncherAimController(RocketLauncher weapon, RocketAim aimPrefab) : base(weapon)
        {
            _aimPrefab = aimPrefab;
            weapon.OnShoot += ApplyAim;
        }

        protected override void MouseDown(ShotData shotData)
        {
            _currentAim = AimsPool.Instance.Pop(_aimPrefab) as RocketAim;
            if (!_currentAim) return;
            
            _currentAim.transform.position = shotData.ShootPosition;
            
            base.MouseDown(shotData);
        }

        protected override void MouseHold(ShotData shotData)
        {
            if (!_currentAim) return;

            _currentAim.transform.position = shotData.ShootPosition;
            
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
