using Effects;
using UnityEngine;

namespace Entities.Interfaces
{
    public interface IEffectable
    {
        void AddEffect(IEffect effect);
        Vector3 GetPosition();
        Transform GetTransform();
    }
}