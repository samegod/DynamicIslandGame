using Buffs.Core;
using UnityEngine;

namespace Buffs
{
    public class Poison : Effect
    {
        private float _delay = 0.5f;
        private float _damage = 1;
        private float _currentDelayTime;
        
        public override void Start() { }

        public override void Update()
        {
            _currentDelayTime += Time.deltaTime;

            if (_currentDelayTime >= _delay)
            {
                _currentDelayTime = 0;
                target.TakeDamage(_damage);
            }
        }
    }
}
