using CodeBase.Enums;
using CodeBase.Gameplay.EnemySystem;
using UnityEngine;

namespace CodeBase.Services.Factories.EnemyFactory
{
    public interface IEnemyFactory
    {
        Enemy Create(EnemyTypeId enemyTypeId, Transform spawnPoint);
    }
}