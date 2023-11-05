using CodeBase.Infrastructure;
using CodeBase.Services.Input;
using CodeBase.Services.Pause;
using CodeBase.Services.SaveSystem;
using CodeBase.Services.WorldData;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindSaveSystem();
            BindWorldDataService();
            BindStateFactory();
            BindGameStateMachine();
            BindLoadingCurtain();
            BindPauseService();
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this).AsSingle();
        }

        private void BindPauseService() =>
            Container
                .Bind<IPauseService>()
                .To<PauseService>()
                .AsSingle();

        private void BindLoadingCurtain() =>
            Container
                .Bind<ILoadingCurtain>()
                .FromInstance(_loadingCurtain)
                .AsSingle();

        private void BindGameStateMachine() =>
            Container.Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();

        public void Initialize()
        {
            var gameStateMachine = Container.Resolve<IGameStateMachine>();
            gameStateMachine.ChangeState<BootstrapState>();
        }

        private void BindStateFactory() =>
            Container
                .Bind<IStateFactory>()
                .To<StateFactory>()
                .AsSingle();

        private void BindWorldDataService() =>
            Container
                .Bind<IWorldDataService>()
                .To<WorldDataService>()
                .AsSingle();

        private void BindSaveSystem() =>
            Container
                .Bind<ISaveSystem>()
                .To<PlayerPrefsSaveSystem>()
                .AsSingle();

        private void BindInputService()
        {
            Container.Bind<IInputService>()
                .To<InputService>()
                .AsSingle();
        }
    }
}