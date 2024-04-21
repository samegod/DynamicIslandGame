using Artifacts.Core;
using UnityEngine;
using Weapons.Core;

namespace DynamicBlob.Core
{
    public class InventoryMediator : MonoBehaviour
    {
        [SerializeField] private InventoryOperator inventoryOperator;
        [SerializeField] private DynamicBlob dynamicBlob;

        private void Awake()
        {
            SubscribeWeapon();
            SubscribeShield();
        }

        private void OnEnable()
        {
            dynamicBlob.OnWeaponSet += SubscribeWeapon;
        }

        private void OnDisable()
        {
            dynamicBlob.OnWeaponSet -= SubscribeWeapon;
        }

        private void SubscribeWeapon()
        {
            if (!dynamicBlob.Weapon)
                return;

            dynamicBlob.Weapon.OnShoot += TrackProjectile;
        }
        
        private void SubscribeShield()
        {
            
        }
        
        private void TrackProjectile(Projectile projectile)
        {
            projectile.OnDealDamage += inventoryOperator.ProcWeapon;
            projectile.OnComplete += UntrackProjectile;
        }

        private void UntrackProjectile(Projectile projectile)
        {
            projectile.OnDealDamage -= inventoryOperator.ProcWeapon;
            projectile.OnComplete -= UntrackProjectile;
        }
    }
}