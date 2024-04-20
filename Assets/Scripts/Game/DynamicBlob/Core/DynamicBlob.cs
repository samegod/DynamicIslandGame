using System;
using Artifacts.Core;
using DynamicBlob.PlayerShield;
using UnityEngine;

namespace DynamicBlob.Core
{
    public class DynamicBlob : MonoBehaviour
    {
        public event Action<Artifact> OnInventoryChanged; 
        
        [SerializeField] private Shield shield;
        [SerializeField] private ArtifactsContainer artifactsContainer;

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            shield.OnShieldBroken += ShieldBroken;
        }

        public void AddArtifact(Artifact newArtifact)
        {
            artifactsContainer.AddArtifact(newArtifact);
            OnInventoryChanged?.Invoke(newArtifact);
        }
        
        private void ShieldBroken()
        {
            Debug.Log("ShieldBroken");
        }
    }
}
