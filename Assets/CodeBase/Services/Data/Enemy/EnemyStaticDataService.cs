using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using CodeBase.ScriptableObjectDatas.Enemy;
using UnityEngine;

namespace CodeBase.Services.Data.Enemy
{
    public class EnemyStaticDataService
    {
        private readonly Dictionary<EnemyTypeId, EnemyData> _enemyDatas;

        public EnemyStaticDataService()
        {
            _enemyDatas = Resources.LoadAll<EnemyData>(nameof(EnemyData))
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }

        public EnemyData Get(EnemyTypeId enemyTypeId) =>
            _enemyDatas[enemyTypeId];
    }
}