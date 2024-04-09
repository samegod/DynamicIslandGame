using DynamicBlob.PlayerShield;
using UnityEngine;

namespace DynamicBlob.Core
{
    public class DynamicBlob : MonoBehaviour
    {
        [SerializeField] private Shield shield;

        private void OnEnable()
        {
            shield.OnShieldBroken += ShieldBroken;
        }

        private void ShieldBroken()
        {
            Debug.Log("ShieldBroken");
        }
    }
}
