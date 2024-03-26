using UnityEngine;

namespace Enemies.Core
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats")]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float speed;

        public float Health => health;
        public float Speed => speed;
    }
}
