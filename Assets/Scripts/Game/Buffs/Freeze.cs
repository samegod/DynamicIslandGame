using Buffs.Core;
using CharacterStats;
using UnityEngine;

namespace Buffs
{
    public class Freeze : Buff
    {
        private IStatsProvider _statsProvider;

        public Freeze(BuffTypeId buffTypeId, float value, float duration, float period) : base(buffTypeId, value, duration, period)
        {
        }

        public override void Start()
        {
            _statsProvider = Target;

            if (_statsProvider == null)
            {
                Debug.Log("Target is not stats provider");
                Stop();
                return;
            }
            
            _statsProvider.SetStatMultiplier(Stats.Speed, Value);
        }

        public override void Stop()
        {
            _statsProvider.SetStatMultiplier(Stats.Speed, Value * -1);
            base.Stop();
        }
    }
}