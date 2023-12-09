namespace Weapons.Core
{
    public abstract class AimController
    {
        public AimController(Weapon weapon)
        {
            weapon.WeaponInput.OnMouseDown += MouseDown;
            weapon.WeaponInput.OnMouseHold += MouseHold;
            weapon.WeaponInput.OnMouseUp += MouseUp;
        }
        
        protected virtual void MouseDown(ShotData obj)
        {
        }

        protected virtual void MouseHold(ShotData obj)
        {
        }
        protected virtual void MouseUp(ShotData obj)
        {
        }
    }
}
