using System;
using UnityEngine;
using Weapons.Core;

namespace Weapons.MachineGunWeapon
{
    public class MachineGun : Weapon
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private ParticleSystem shootParticles;
        [SerializeField] private float shotCooldown;
        [SerializeField] private float rotationSpeed;

        private float _currentShotCooldown;

        private void OnEnable()
        {
            WeaponInput.OnMouseHold += Shoot;
        }

        private void OnDisable()
        {
            WeaponInput.OnMouseHold -= Shoot;
        }

        private void Update()
        {
            if (_currentShotCooldown > 0f)
            {
                _currentShotCooldown -= Time.deltaTime;
            }
        }

        public override void Shoot(ShotData data)
        {
            RotateToTarget(data.ShootPosition);

            if (_currentShotCooldown <= 0f)
            {
                Bullet newBullet = ProjectilesPool.Instance.Pop(bulletPrefab) as Bullet;
                if (!newBullet) return;

                newBullet.transform.position = shootPoint.position;
                newBullet.transform.rotation = transform.rotation;
                newBullet.SetDamage(damage);
                AddEffects(newBullet);
                newBullet.Shoot();
                
                _currentShotCooldown = shotCooldown;
                shootParticles.Play();
            }
        }

        private void RotateToTarget(Vector3 targetPosition)
        {
            Vector3 relativePos = targetPosition - transform.position;

            Quaternion newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            Vector3 newEulerAngles = newRotation.eulerAngles;
            newEulerAngles.x = 0f;
            newEulerAngles.z = 0f;

            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, newEulerAngles, Time.deltaTime * rotationSpeed);
        }
    }
}