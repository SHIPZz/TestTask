using CodeBase.Enums;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Infrastructure;
using CodeBase.Services.Player;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Windows
{
    public class DeathWindowPresenter : MonoBehaviour
    {
        [SerializeField] private DeathView _deathView;

        private IGameStateMachine _gameStateMachine;
        private WindowService _windowService;
        private IHealth _playerHealth;
        private PlayerService _playerService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, WindowService windowService, PlayerService playerService)
        {
            _playerService = playerService;
            _windowService = windowService;
            _gameStateMachine = gameStateMachine;
            _playerService.Dead += OnPlayerDead;
        }

        private void OnEnable() => 
            _deathView.ButtonPressed += _gameStateMachine.ChangeState<BootstrapState>;

        private void OnDisable()
        {
            _deathView.ButtonPressed -= _gameStateMachine.ChangeState<BootstrapState>;
            _playerService.Dead -= OnPlayerDead;
        }

        private void OnPlayerDead() => 
            _windowService.Open(WindowTypeId.Death);
    }
}