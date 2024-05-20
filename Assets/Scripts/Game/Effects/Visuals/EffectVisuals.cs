using System.Collections;
using Additions.Pool;
using Effects.Visuals.Pool;
using UnityEngine;

namespace Effects.Visuals
{
    public abstract class EffectVisuals : MonoBehaviourPoolObject, IEffectVisuals
    {
        [SerializeField] private float duration;
        
        public virtual void Activate()
        {
            StartCoroutine(DelayedDisable());
        }
        
        public void SetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        protected virtual void Disable()
        {
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