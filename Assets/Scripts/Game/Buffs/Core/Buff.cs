using Buffs.Interfaces;
using Enemies.Core;
using UnityEngine;

namespace Buffs.Core
{
    public abstract class Buff : IBuff
    {
        protected readonly BuffTypeId BuffTypeId;
        protected readonly float Value;
        protected readonly float Duration;
        protected readonly float Period;
        protected Enemy Target;
        protected bool IsWorking = true;

        private float _currentDuration;
        
        protected BuffTypeId TypeId => BuffTypeId;
        
        protected Buff(BuffTypeId buffTypeId, float value, float duration, float period)
        {
            BuffTypeId = buffTypeId;
            Value = value;
            Duration = duration;
            Period = period;
        }


        public abstract void Start();
        public virtual void Update()
        {
            if (!IsWorking)
                return;
            
            _currentDuration += Time.deltaTime;

            if (_currentDuration >= Duration)
            {
               Stop(); 
            }
        }

        public virtual void Stop()
        {
            IsWorking = false;
        }
        
        public void InitEnemy(Enemy targetEnemy)
        {
            Target = targetEnemy;
        }
    }
}
