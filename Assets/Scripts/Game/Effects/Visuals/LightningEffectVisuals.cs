using System;
using DG.Tweening;
using UnityEngine;

namespace Effects.Visuals
{
    public class LightningEffectVisuals : EffectVisuals
    {
        public override void Activate(Transform target, Action callback = null)
        {
            transform.DOMove(target.position, duration).SetEase(Ease.Linear).OnComplete(() => callback?.Invoke());
        }
    }
}