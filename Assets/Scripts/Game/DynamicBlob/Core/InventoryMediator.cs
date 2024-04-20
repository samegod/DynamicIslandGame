using System;
using Artifacts.Core;
using UnityEngine;
using Weapons.Core;

namespace DynamicBlob.Core
{
    public class InventoryMediator : MonoBehaviour
    {
        [SerializeField] private DynamicBlob dynamicBlob;
        [SerializeField] private Weapon weapon;

        private void OnEnable()
        {
            dynamicBlob.OnInventoryChanged += AddArtifact;
        }

        private void OnDisable()
        {
            dynamicBlob.OnInventoryChanged -= AddArtifact;
        }

        private void AddArtifact(Artifact newArtifact)
        {
            weapon.ArtifactsManager.AddBuff(newArtifact);
        }
    }
}