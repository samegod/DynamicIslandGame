using UnityEngine;

namespace Effects.Visuals
{
    public interface IEffectVisuals
    {
        void Activate();
        void SetPosition(Vector3 newPosition);
    }
}