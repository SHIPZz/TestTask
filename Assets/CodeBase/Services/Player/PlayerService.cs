using System;
using CodeBase.Gameplay.PlayerSystem;

namespace CodeBase.Services.Player
{
    public class PlayerService : IDisposable
    {
        private Gameplay.PlayerSystem.Player _player;
        private IHealth _playerHealth;

        public event Action Dead;

        public void SetPlayer(Gameplay.PlayerSystem.Player player)
        {
            _player = player;
            _playerHealth = player.GetComponent<IHealth>();
            _playerHealth.Dead += SetDead;
        }

        private void SetDead() =>
            Dead?.Invoke();

        public void Dispose() => 
            _playerHealth.Dead -= SetDead;
    }
}