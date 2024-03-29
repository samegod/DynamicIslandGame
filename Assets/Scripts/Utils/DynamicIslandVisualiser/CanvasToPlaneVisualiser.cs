using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.U2D;

namespace Utils.DynamicIslandVisualiser
{
    public class CanvasToPlaneVisualiser : MonoBehaviour
    {
        [SerializeField] private float raycastDistance;
        [SerializeField] private Transform camera;
        [SerializeField] private RectTransform uiObjectToShow;
        [SerializeField] private SpriteShapeController spriteShape;

        [Button]
        public void ShowShadow()
        {
            Vector3[] corners = new Vector3[4];
            uiObjectToShow.GetWorldCorners(corners);

            for (int i = 0; i < corners.Length; i++)
            {
                Vector3 direction = corners[i] - camera.position;

                RaycastHit hit;
                Physics.Raycast(camera.position, direction * raycastDistance, out hit);
                Debug.DrawRay(camera.position, direction * raycastDistance, Color.yellow);

                Vector3 newCornerPosition = hit.point;
                newCornerPosition.y = newCornerPosition.z;
                newCornerPosition.z = 0;
                spriteShape.spline.SetPosition(i, newCornerPosition);
            }
        }
    }
}
