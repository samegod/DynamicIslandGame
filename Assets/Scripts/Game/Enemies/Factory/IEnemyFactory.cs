using Enemies.Core;
using UnityEngine;

namespace Enemies.Factory
{
    public interface IEnemyFactory
    {
        void CreateEnemy(EnemyTypeId typeId, Vector3 spawnPosition);
    }
}