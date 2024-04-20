using Buffs.Interfaces;
using Enemies.Core;

namespace Buffs.Core
{
    public abstract class Buff : IBuff
    {
        protected float duration;
        protected Enemy target;

        public abstract void Start();
        public abstract void Update();
        
        public void InitEnemy(Enemy targetEnemy)
        {
            target = targetEnemy;
        }

        public int GetProcChance()
        {
            return 1;
        }
    }
}
