using DynamicBlob.PlayerShield;
using Enemies.Core;
using Interfaces;
using Sirenix.Utilities;
using UnityEngine;
using Weapons.Core;

namespace Artifacts.Core
{
    public class InventoryOperator : MonoBehaviour
    {
        private Inventory _inventory;
        private Weapon _weapon;
        private Shield _shield;
        
        public void SetInventory(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void SetShield(Shield shield)
        {
            _shield = shield;
        }
        
        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            
        }
        
        public void ProcWeapon(IHittable target)
        {
            if (_inventory.WeaponProcables.IsNullOrEmpty())
                return;
            
            if (target is Enemy enemy)
            {
                float random = Random.Range(0f, 1f);
                
                foreach (var procable in _inventory.WeaponProcables)
                {
                    if (random <= procable.GetProcChance() * _weapon.ProcChance)
                    {
                        procable.Proc(enemy);
                    }
                }
            }
        }

        public void ProcShield()
        {
            
        }
    }
}