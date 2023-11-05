using CodeBase.Enums;
using CodeBase.Gameplay.EnemySystem;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Gameplay.Spawners.Enemy;
using CodeBase.Services.Factories.Player;
using CodeBase.Services.Player;
using CodeBase.Services.Providers;
using Zenject;

namespace CodeBase.GameInitializer
{
    public class GameInit : IInitializable
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly CameraProvider _cameraProvider;
        private readonly LocationProvider _locationProvider;
        private readonly EnemySpawnersProvider _enemySpawnersProvider;
        private readonly EnemyProvider _enemyProvider;
        private readonly PlayerService _playerService;

        public GameInit(IPlayerFactory playerFactory, 
            CameraProvider cameraProvider,
            LocationProvider locationProvider, 
            EnemySpawnersProvider enemySpawnersProvider,
            EnemyProvider enemyProvider,
            PlayerService playerService)
        {
            _playerService = playerService;
            _enemyProvider = enemyProvider;
            _enemySpawnersProvider = enemySpawnersProvider;
            _playerFactory = playerFactory;
            _cameraProvider = cameraProvider;
            _locationProvider = locationProvider;
        }

        public void Initialize()
        {
            Player player = InitializePlayer();
            _playerService.SetPlayer(player);
            InitializeEnemies(player);
            InitializeCamera(player);
        }

        private void InitializeEnemies(Player player)
        {
            foreach (EnemySpawner enemySpawner in _enemySpawnersProvider.EnemySpawners)
            {
                enemySpawner.Init(enemy =>
                {
                    enemy.GetComponent<EnemyFollower>().SetPlayer(player);
                    _enemyProvider.Enemies.Add(enemy);
                });
            }
        }

        private void InitializeCamera(Player player)
        {
            _cameraProvider.CameraFollower.SetTarget(player.transform);
        }

        private Player InitializePlayer()
        {
            Player player = _playerFactory.Create(PlayerTypeId.DefaultPlayer,
                _locationProvider.Get(LocationTypeId.PlayerSpawnPoint));
            return player;
        }
    }
}