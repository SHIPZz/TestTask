using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using CodeBase.ScriptableObjectDatas.Player;
using UnityEngine;

namespace CodeBase.Services.Data.Player
{
    public class PlayerStaticDataService
    {
        private readonly Dictionary<PlayerTypeId, PlayerData> _playerDatas;

        public PlayerStaticDataService()
        {
            _playerDatas = Resources.LoadAll<PlayerData>(nameof(PlayerData))
                .ToDictionary(x => x.PlayerTypeId, x => x);
        }

        public PlayerData Get(PlayerTypeId playerTypeId) =>
            _playerDatas[playerTypeId];
    }
}