using Items.Interfaces;
using Weapons.Core;

namespace Items
{
    public abstract class WeaponItem : Item, IWeaponItem
    {
        public void SetTrackedWeapon(Weapon weapon)
        {
            
        }

        protected abstract void OnWeaponShoot(Projectile projectile);
    }
}