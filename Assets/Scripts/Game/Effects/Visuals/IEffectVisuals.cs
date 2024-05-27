using System;
using UnityEngine;

namespace Effects.Visuals
{
    public interface IEffectVisuals
    {
        void Activate(Action callback = null);
        void Activate(Transform target, Action callback = null);
        void SetPosition(Vector3 newPosition);
    }
}