using Enemies.Core;

namespace Buffs.Interfaces
{
    public interface IBuff
    {
        void InitEnemy(Enemy enemy);
        void Start();
        void Update();
    }
}