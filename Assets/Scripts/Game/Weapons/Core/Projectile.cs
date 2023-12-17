using System;
using Additions.Pool;
using UnityEngine;
using Weapons.Core.Interfaces;

namespace Weapons.Core
{
    public abstract class Projectile : MonoBehaviourPoolObject, IProjectile
    {
        [SerializeField] protected float damage;
        
        public event Action OnComplete;

        protected void Complete()
        {
            OnComplete?.Invoke();
        }
        
        public override void Push()
        {
            ProjectilesPool.Instance.Push(this);
        }
    }
}
