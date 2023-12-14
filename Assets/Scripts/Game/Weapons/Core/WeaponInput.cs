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

        private ShotData CreateShotData(Vector3 mousePosition)
        {
            ShotData shotData = new ShotData();

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = _mainCamera.nearClipPlane + 1;
            var mouseWorldPos = _mainCamera.ScreenToWorldPoint(mousePos);
            shotData.ShootPosition2D = mouseWorldPos;
            shotData.ShootPosition = mousePosition;
            
            return shotData;
        }

        private Vector3 GetMousePosition()
        {
            Vector3 clickPosition = Vector3.zero;
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 500, LayerMask.GetMask("InputLayer")))
            {
                clickPosition = hit.point;
            }

            return clickPosition;
        }
    }
}