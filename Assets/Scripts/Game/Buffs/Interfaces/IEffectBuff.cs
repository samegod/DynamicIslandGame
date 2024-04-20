using Enemies.Core;

namespace Buffs.Interfaces
{
    public interface IEffectBuff
    {
        void InitEnemy(Enemy enemy);
        void Start();
        void Update();
    }
}