using System;
using Interfaces;
using UnityEngine;
using Weapons.Core;

namespace Weapons.MachineGunWeapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rigidbody;

        private void Reset()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Shoot()
        {
            rigidbody.velocity = transform.forward * speed;
        }

        private void OnCollisionEnter(Collision other)
        {
            IHittable enemy = other.transform.GetComponent<IHittable>();

            if (enemy == null)
                return;
            
            enemy.TakeDamage(5f);
            Push();
        }
    }
}
