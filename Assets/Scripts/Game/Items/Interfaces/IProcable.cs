using Enemies.Core;

namespace Items.Interfaces
{
    public interface IProcable : IItem
    {
        float GetProcChance();
        void Proc(Enemy enemy);
    }
}