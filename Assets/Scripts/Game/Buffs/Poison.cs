using Buffs.Core;
using UnityEngine;

namespace Buffs
{
    public class Poison : Buff
    {
        private float _currentPeriodTime;

        public Poison(float value, float duration, float period) : base(value, duration, period)
        {
        }

        public override void Start() { }

        public override void Update()
        {
            _currentPeriodTime += Time.deltaTime;

            if (_currentPeriodTime >= Period)
            {
                _currentPeriodTime = 0;
                Target.TakeDamage(Value);
            }
        }
    }
}
