using CodeBase.Enums;
using CodeBase.Gameplay.Triggers;
using CodeBase.Infrastructure;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Windows
{
    public class VictoryWindowPresenter : MonoBehaviour
    {
        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private FinishTrigger _finishTrigger;
        
        private IGameStateMachine _gameStateMachine;
        private WindowService _windowService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, WindowService windowService)
        {
            _windowService = windowService;
            _gameStateMachine = gameStateMachine;
        }

        private void OnEnable()
        {
            _victoryView.ButtonPressed += _gameStateMachine.ChangeState<BootstrapState>;
            _finishTrigger.PlayerEntered += OnFinishTriggered;
        }

        private void OnDisable()
        {
            _victoryView.ButtonPressed -= _gameStateMachine.ChangeState<BootstrapState>;
            _finishTrigger.PlayerEntered -= OnFinishTriggered;
        }

        private void OnFinishTriggered()
        {
            _windowService.Open(WindowTypeId.Victory);
        }
    }
}