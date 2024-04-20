using Weapons.Core;

namespace Interfaces
{
    public interface IHittable
    {
        void TakeDamage(float damage);
        void TakeDamage(HitData hitData);
    }
}
