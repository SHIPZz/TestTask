using System;
using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Gameplay.EnemySystem;
using CodeBase.Services.Factories.EnemyFactory;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Spawners.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyTypeId _enemyTypeId;
        [SerializeField] private List<Transform> _movementPoints;

        private IEnemyFactory _enemyFactory;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Init(Action<EnemySystem.Enemy> callback)
        {
            EnemySystem.Enemy enemy = _enemyFactory.Create(_enemyTypeId, transform);
            enemy.GetComponent<EnemyFollower>().SetMovementPoints(_movementPoints);
            callback?.Invoke(enemy);
        }
    }
}