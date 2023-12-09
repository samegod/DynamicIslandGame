using System;
using UnityEngine;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class WeaponInput : MonoBehaviour, IWeaponInput
    {
        public event Action<ShotData> OnMouseDown;
        public event Action<ShotData> OnMouseHold;
        public event Action<ShotData> OnMouseUp;
        
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
                MouseDown();
            }

            if (Input.GetMouseButton(0))
            {
                MouseHold();
            }

            if (Input.GetMouseButtonUp(0))
            {
                MouseUp();
            }
        }

        private void MouseDown()
        {
            ShotData shotData = CreateShotData(GetMousePosition());
            OnMouseDown?.Invoke(shotData);
        }

        private void MouseHold()
        {
            ShotData shotData = CreateShotData(GetMousePosition());
            OnMouseHold?.Invoke(shotData);
        }

        private void MouseUp()
        {
            ShotData shotData = CreateShotData(GetMousePosition());
            OnMouseUp?.Invoke(shotData);
        }

        private ShotData CreateShotData(Vector2 mousePosition)
        {
            ShotData shotData = new ShotData();
            shotData.ShootPosition = mousePosition;
            return shotData;
        }
        
        private Vector2 GetMousePosition()
        {
            var mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            return mouseWorldPos;
        }
    }
}
