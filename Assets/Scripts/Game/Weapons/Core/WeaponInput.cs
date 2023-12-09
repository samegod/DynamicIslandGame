using UnityEngine;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class WeaponInput : MonoBehaviour, IWeaponInput
    {
        [SerializeField] protected Weapon weapon;
    }
}
