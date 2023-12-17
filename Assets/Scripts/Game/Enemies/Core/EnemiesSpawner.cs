using Enemies.Pool;
using UnityEngine;

namespace Enemies.Core
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Enemy enemy;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private float spawnRate;

        private float _lastSpawnTime;

        private void Update()
        {
            if (_lastSpawnTime >= spawnRate)
            {
                SpawnEnemy();
                _lastSpawnTime = 0f;
            }

            _lastSpawnTime += Time.deltaTime;
        }

        private void SpawnEnemy()
        {
            Enemy newEnemy = EntitiesPool.Instance.Pop(enemy) as Enemy;
            if (newEnemy == null) return;
            
            newEnemy.transform.position = spawnPosition.position;
            newEnemy.Init(player);
        }
    }
}