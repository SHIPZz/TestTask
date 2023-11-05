using CodeBase.Enums;
using CodeBase.Gameplay.EnemySystem;
using CodeBase.ScriptableObjectDatas.Enemy;
using CodeBase.Services.Data.Enemy;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factories.EnemyFactory
{
    public class EnemyFactory : IEnemyFactory
    {
        private EnemyStaticDataService _enemyStaticDataService;
        private DiContainer _diContainer;

        public EnemyFactory(EnemyStaticDataService enemyStaticDataService, DiContainer diContainer)
        {
            _enemyStaticDataService = enemyStaticDataService;
            _diContainer = diContainer;
        }

        public Enemy Create(EnemyTypeId enemyTypeId, Transform spawnPoint)
        {
            EnemyData enemyData = _enemyStaticDataService.Get(enemyTypeId);
            Enemy enemy = _diContainer.InstantiatePrefabForComponent<Enemy>(enemyData.Prefab, spawnPoint.position,
                Quaternion.identity, null);
            enemy.GetComponent<EnemyFollower>().SetSpeed(enemyData.Speed);
            return enemy;
        }
    }
}