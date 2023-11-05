using System.Collections.Generic;
using CodeBase.Gameplay.Spawners.Enemy;
using UnityEngine;

namespace CodeBase.Services.Providers
{
    public class EnemySpawnersProvider : MonoBehaviour 
    {
        [SerializeField] private List<EnemySpawner> _enemySpawners;

        public IReadOnlyList<EnemySpawner> EnemySpawners => _enemySpawners;
    }
}