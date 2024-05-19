using Buffs.Interfaces;
using Enemies.Core;

namespace Buffs.Core
{
    public abstract class Buff : IBuff
    {
        protected readonly float Value;
        protected readonly float Duration;
        protected readonly float Period;
        protected Enemy Target;

        public abstract void Start();
        public abstract void Update();

        protected Buff(float value, float duration, float period)
        {
            Value = value;
            Duration = duration;
            Period = period;
        }
        
        public void InitEnemy(Enemy targetEnemy)
        {
            Target = targetEnemy;
        }
    }
}
