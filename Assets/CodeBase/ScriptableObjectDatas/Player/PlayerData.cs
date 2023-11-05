using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.ScriptableObjectDatas.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Gameplay/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [Range(5, 15)] public float Speed;
        public PlayerTypeId PlayerTypeId;
        public Gameplay.PlayerSystem.Player Prefab;
        [Range(100,200)] public int Health;
    }
}