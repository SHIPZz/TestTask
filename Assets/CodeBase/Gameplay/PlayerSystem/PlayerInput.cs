using System;
using CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerInput : MonoBehaviour
    {
        private IInputService _inputService;

        public event Action<Vector2> MovementPressed;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            MovementPressed?.Invoke(_inputService.Movement);
        }
    }
}