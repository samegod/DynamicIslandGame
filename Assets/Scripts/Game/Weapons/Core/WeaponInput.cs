using UnityEngine;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class WeaponInput : MonoBehaviour, IWeaponInput
    {
        [SerializeField] protected Weapon weapon;

        private Camera _mainCamera;

        protected virtual void Awake()
        {
            _mainCamera = Camera.main;
        }

        protected void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseDown(GetMousePosition());
            }

            if (Input.GetMouseButton(0))
            {
                MouseHold(GetMousePosition());
            }

            if (Input.GetMouseButtonUp(0))
            {
                MouseUp(GetMousePosition());
            }
        }

        protected virtual void MouseDown(Vector2 position) { }

        protected virtual void MouseHold(Vector2 position) { }

        protected virtual void MouseUp(Vector2 position) { }

        private Vector2 GetMousePosition()
        {
            var mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            return mouseWorldPos;
        }
    }
}
