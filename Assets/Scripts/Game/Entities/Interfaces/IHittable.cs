using Weapons.Core;

namespace Entities.Interfaces
{
    public interface IHittable
    {
        void TakeDamage(float damage);
        void TakeDamage(HitData hitData);
    }
}
