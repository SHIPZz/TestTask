using CodeBase.GameInitializer;
using CodeBase.Services.Data.Enemy;
using CodeBase.Services.Data.Player;
using CodeBase.Services.Factories.EnemyFactory;
using CodeBase.Services.Factories.Player;
using CodeBase.Services.Player;
using CodeBase.Services.Providers;
using CodeBase.Services.UI;
using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LocationProvider _locationProvider;
        [SerializeField] private CameraProvider _cameraProvider;
        [SerializeField] private EnemySpawnersProvider _enemySpawnersProvider;
        [SerializeField] private WindowProvider _windowProvider;
        
        public override void InstallBindings()
        {
            BindGameInit();
            BindPlayerFactory();
            BindPlayerStaticDataService();
            BindLocationProvider();
            BindCameraProvider();
            BindPlayerProvider();
            BindEnemySpawnersProvider();
            BindEnemyProvider();
            BindEnemyFactory();
            BindEnemyStaticDataService();
            BindWindowProvider();
            BindWindowService();
        }

        private void BindWindowProvider() => 
            Container.BindInstance(_windowProvider).AsSingle();

        private void BindWindowService() => 
            Container.Bind<WindowService>().AsSingle();

        private void BindEnemyProvider() =>
            Container
                .Bind<EnemyProvider>()
                .AsSingle();

        private void BindEnemySpawnersProvider() => 
            Container.BindInstance(_enemySpawnersProvider);

        private void BindEnemyStaticDataService() =>
            Container
                .Bind<EnemyStaticDataService>()
                .AsSingle();

        private void BindEnemyFactory() =>
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();

        private void BindGameInit() =>
            Container
                .BindInterfacesAndSelfTo<GameInit>()
                .AsSingle();

        private void BindPlayerProvider() => 
            Container.BindInterfacesAndSelfTo<PlayerService>().AsSingle();

        private void BindCameraProvider()
        {
            Container.BindInstance(_cameraProvider);
        }

        private void BindLocationProvider() => 
            Container.BindInstance(_locationProvider);

        private void BindPlayerStaticDataService() => 
            Container.Bind<PlayerStaticDataService>().AsSingle();

        private void BindPlayerFactory() =>
            
            Container.Bind<IPlayerFactory>()
                .To<PlayerFactory>()
                .AsSingle();
    }
}