using System;
using UnityEngine;
using Weapons.Core;

namespace Weapons.MachineGunWeapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rigidbody;

        private bool _beenShot;

        private void Reset()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!_beenShot) return;
            
            //transform.Translate(transform.forward * (Time.deltaTime * speed));
        }

        public void Shoot()
        {
            _beenShot = true;
            rigidbody.velocity = transform.forward * speed;
        }
    }
}
