using Effects;
using UnityEngine;

namespace Entities.Interfaces
{
    public interface IEffectable
    {
        Vector3 GetPosition();
        Transform GetTransform();
    }
}