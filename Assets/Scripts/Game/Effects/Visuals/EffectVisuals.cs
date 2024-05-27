using System;
using System.Collections;
using Additions.Pool;
using Effects.Visuals.Pool;
using UnityEngine;

namespace Effects.Visuals
{
    public abstract class EffectVisuals : MonoBehaviourPoolObject, IEffectVisuals
    {
        [SerializeField] protected float duration;

        protected Action Callback;
        
        public virtual void Activate(Action callback = null)
        {
            Callback = callback;
            StartCoroutine(DelayedDisable());
        }

        public virtual void Activate(Transform target, Action callback = null)
        {
            Callback = callback;
            StartCoroutine(DelayedDisable());
        }
        
        public void SetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        public virtual void Disable()
        {
            Callback?.Invoke();
            Push();
        }

        private IEnumerator DelayedDisable()
        {
            yield return new WaitForSeconds(duration);
            Disable();
        }
        
        public override void Push()
        {
            EffectVisualsPool.Instance.Push(this);
        }
    }
}