using UnityEngine;
using Weapons.Core;

namespace Weapons.RocketLauncherWeapon.Aim
{
    public class RocketAim : Core.Aim
    {
        [SerializeField] private AimAppearEffect appearEffect;
        [SerializeField] private AimApplyEffect applyEffect;

        private Projectile _currentlyTrackingProjectile;
        
        public override void OnPop()
        {
            appearEffect.StartEffect();
            base.OnPop();
        }

        public void TrackProjectile(Projectile projectile)
        {
            projectile.OnComplete += Hide;
            _currentlyTrackingProjectile = projectile;
        }
        
        public void Apply()
        {
            appearEffect.StopEffect(false);
            applyEffect.StartEffect();
        }

        public void Hide()
        {
            _currentlyTrackingProjectile.OnComplete -= Hide;
            _currentlyTrackingProjectile = null;
            Push();
        }
    }
}
