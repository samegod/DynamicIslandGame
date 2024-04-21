using System;
using Artifacts.Core;
using DynamicBlob.PlayerShield;
using UnityEngine;
using Weapons.Core;

namespace DynamicBlob.Core
{
    public class DynamicBlob : MonoBehaviour
    {
        public event Action OnWeaponSet;

        [SerializeField] private Weapon weapon;
        [SerializeField] private Shield shield;
        [SerializeField] private ArtifactsContainer artifactsContainer;

        private Inventory _inventory;

        public Weapon Weapon => weapon;
        public Shield Shield => shield;
        public Inventory Inventory => _inventory;

        private void Awake()
        {
            _inventory = new Inventory();
        }

        private void OnEnable()
        {
            shield.OnShieldBroken += ShieldBroken;
        }

        public void AddArtifact(Artifact newArtifact)
        {
            _inventory.AddArtifact(newArtifact);
        }
        
        private void ShieldBroken()
        {
            Debug.Log("ShieldBroken");
        }
    }
}
