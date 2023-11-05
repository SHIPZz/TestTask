using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.Gameplay.EnemySystem
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public EnemyTypeId EnemyTypeId { get; private set; }
    }
}