using Buffs.Core;
using UnityEngine;

namespace Buffs
{
    public class Poison : Buff
    {
        private float _currentPeriodTime;

        public Poison(BuffTypeId buffTypeId, float value, float duration, float period) : base(buffTypeId, value, duration, period)
        {
        }

        public override void Start() { }

        public override void Update()
        {
            base.Update();
            
            if (!IsWorking)
                return;
            
            _currentPeriodTime += Time.deltaTime;

            if (_currentPeriodTime >= Period)
            {
                _currentPeriodTime = 0;
                Target.TakeDamage(Value);
            }
        }
    }
}
