using System.Collections.Generic;
using Enemies.Core;
using Entities.Interfaces;
using Items.Interfaces;
using Sirenix.Utilities;
using UnityEngine;
using Weapons.Core;

namespace Items
{
    public class ItemsInventory : MonoBehaviour
    {
        [SerializeField, Min(0)] private float procChance;

        private List<IProcable> _procables = new List<IProcable>();
        private List<IStat> _stats = new List<IStat>();
        private Weapon _weapon;

        public void InitWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _weapon.OnShoot += TrackProjectile;
        }
        
        public void AddItem(IItem newItem)
        {
            if (newItem is IProcable procable)
            {
                _procables.Add(procable);
            }
            if (newItem is IStat stat) 
            {
                _stats.Add(stat);
            }
        }
        
        private void DamageDealt(IHittable target)
        {
            if (_procables.IsNullOrEmpty())
                return;
            
            if (target is Enemy enemy)
            {
                float random = Random.Range(0f, 1f);
                
                foreach (var procable in _procables)
                {
                    if (random <= procable.GetProcChance() * procChance)
                    {
                        procable.Proc(enemy);
                    }
                }
            }
        }
        
        private void TrackProjectile(Projectile projectile)
        {
            projectile.OnDealDamage += DamageDealt;
            projectile.OnComplete += UnTrackProjectile;
        }

        private void UnTrackProjectile(Projectile projectile)
        {
            projectile.OnDealDamage -= DamageDealt;
            projectile.OnComplete -= UnTrackProjectile;
        }
    }
}