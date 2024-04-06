using Interfaces;
using UnityEngine;

namespace DynamicBlob.Core
{
    public class DynamicBlob : MonoBehaviour,IHittable
    {
        public void TakeDamage(float damage)
        {
            Debug.Log("take " + damage + " damage");
        }
    }
}
