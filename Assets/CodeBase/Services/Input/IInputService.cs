using UnityEngine;

namespace CodeBase.Services.Input 
{
    public interface IInputService
    {
        Vector2 Movement { get; }
    }

    public class InputService : IInputService
    {
        private readonly PlayerActions _playerActions;

        public InputService()
        {
            _playerActions = new PlayerActions();
            _playerActions.Enable();
        }

        public Vector2 Movement => _playerActions.PlayerMovement.Move.ReadValue<Vector2>();
    }
}