using UnityEngine;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerMovementMediator : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerMovement _playerMovement;

        private void OnEnable() =>
            _playerInput.MovementPressed += _playerMovement.SetMovement;

        private void OnDisable() =>
            _playerInput.MovementPressed -= _playerMovement.SetMovement;
    }
}