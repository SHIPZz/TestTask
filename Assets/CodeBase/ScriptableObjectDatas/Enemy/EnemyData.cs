using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.ScriptableObjectDatas.Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Gameplay/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [Range(3, 15)] public float Speed;
        public EnemyTypeId EnemyTypeId;
        public Gameplay.EnemySystem.Enemy Prefab;
        [Range(1000,1000)] public int Damage;
    }
}