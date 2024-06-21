using System;
using Artifacts.Core;
using CharacterInventory;
using CharacterInventory.ArtifactsProc;
using DynamicBlob.PlayerShield;
using Entities.Interfaces;
using UnityEngine;
using Weapons.Core;
using Zenject;

namespace DynamicBlob.Core
{
    public class DynamicBlob : MonoBehaviour, IInventoryOwner
    {
        public event Action<IHittable> OnDamageTaken;
        public event Action<IHittable> OnShoot;
        public event Action<IHittable> OnImpact;

        [SerializeField] private Weapon weapon;
        [SerializeField] private Shield shield;

        private IInventory _inventory;
        private IArtifactsProcService _procService;

        public Weapon Weapon => weapon;
        public Shield Shield => shield;

        private void Awake()
        {
            _inventory = new Inventory(this, _procService);
        }

        [Inject]
        private void Construct(IArtifactsProcService procService)
        {
            _procService = procService;
        }

        private void Start()
        {
            if (weapon)
            {
                SetWeapon(weapon);
            }
        }

        private void OnEnable()
        {
            shield.OnShieldBroken += ShieldBroken;
        }

        public void SetWeapon(Weapon newWeapon)
        {
            if (weapon && newWeapon != weapon)
            {
                weapon.OnImpact -= DamageDealt;
            }

            weapon = newWeapon;

            weapon.OnImpact += DamageDealt;
        }
        
        public void AddArtifact(Artifact newArtifact)
        {
            _inventory.AddArtifact(newArtifact);
        }

        private void DamageDealt(IHittable target)
        {
            OnImpact?.Invoke(target);
        }
        
        private void ShieldBroken()
        {
            Debug.Log("ShieldBroken");
        }
    }
}
