using System;
using Artifacts.Core;
using Buffs.Factory;
using CharacterInventory;
using CharacterInventory.ArtifactsProc;
using CharacterStats;
using DynamicBlob.PlayerShield;
using Effects.Factory;
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
        private IStatsHolder _statsHolder;
        private IArtifactsProcService _procService;

        public Weapon Weapon => weapon;
        public Shield Shield => shield;

        private void Awake()
        {
            _inventory = new Inventory(this, _procService);
            _statsHolder = new StatsHolder();
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

        public IStatsHolder GetStatHolder()
        {
            return _statsHolder;
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
