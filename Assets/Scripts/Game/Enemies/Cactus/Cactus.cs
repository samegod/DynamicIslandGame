using Enemies.Core;

namespace Enemies.Cactus
{
    public class Cactus : Enemy
    {
        protected override void Start()
        {
            base.Start();
            //buffsHolder.AddBuff(new Poison());
        }
    }
}
