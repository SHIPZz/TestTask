using CodeBase.Enums;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.ScriptableObjectDatas.Player;
using CodeBase.Services.Data;
using CodeBase.Services.Data.Player;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factories.Player
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerStaticDataService _playerStaticDataService;
        private readonly DiContainer _diContainer;

        public PlayerFactory(PlayerStaticDataService playerStaticDataService,DiContainer diContainer)
        {
            _diContainer = diContainer;
            _playerStaticDataService = playerStaticDataService;
        }

        public Gameplay.PlayerSystem.Player Create(PlayerTypeId playerTypeId, Transform spawnPoint)
        {
            PlayerData playerData = _playerStaticDataService.Get(playerTypeId);
            Gameplay.PlayerSystem.Player playerPrefab = playerData.Prefab;  
            var player = _diContainer
                .InstantiatePrefabForComponent<Gameplay.PlayerSystem.Player>(playerPrefab, 
                    spawnPoint.position,
                    Quaternion.identity, 
                    null);
            
            player.GetComponent<PlayerMovement>().SetSpeed(playerData.Speed);
            player.GetComponent<PlayerHealth>().Increase(playerData.Health);
            return player;
        }
    }
}