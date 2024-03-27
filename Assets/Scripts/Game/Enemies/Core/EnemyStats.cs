using UnityEngine;

namespace Enemies.Core
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats")]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] private float attackRange;
        [SerializeField] private float fireRate;

        public float Health => health;
        public float Speed => speed;
        public float Damage => damage;
        public float AttackRange => attackRange;
        public float FireRate => fireRate;
    }
}
