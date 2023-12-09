using UnityEngine;
using Weapons.Core;

namespace Weapons.RocketLauncherWeapon
{
    public class RocketLauncherInput : WeaponInput
    {
        protected override void MouseDown(Vector2 position)
        {
            base.MouseDown(position);
            
            weapon.Shoot(CreateShotData(position));
        }

        private ShotData CreateShotData(Vector2 mousePosition)
        {
            ShotData shotData = new ShotData();
            shotData.ShootPosition = mousePosition;
            return shotData;
        }
    }
}
