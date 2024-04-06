using UnityEngine;

namespace Enemies.Core
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private DynamicBlob.Core.DynamicBlob blob;
        
        private void Start()
        {
            enemy.StartFight(blob);
        }
    }
}
