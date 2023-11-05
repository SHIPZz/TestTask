using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Gameplay.TriggerObservers;
using UnityEngine;

namespace CodeBase.Gameplay.EnemySystem
{
    public class EnemyDamageZone : MonoBehaviour
    {
        private const float TargetKillTime = 1f;
        
        [SerializeField] private TriggerObserver _triggerObserver;

        private bool _isPlayerInZone;
        private float _playerTimeInZone;
        private IHealth _player;
        private bool _isKilled;

        private void OnEnable()
        {
            _triggerObserver.TriggerEntered += OnTriggerEntered;
            _triggerObserver.TriggerExited += OnTriggerExited;
        }

        private void Update()
        {
            if (!_isPlayerInZone)
                return;
            
            _playerTimeInZone += Time.deltaTime;

            if (_playerTimeInZone >= TargetKillTime)
            {
                KillPlayer();
            }
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEntered -= OnTriggerEntered;
            _triggerObserver.TriggerExited -= OnTriggerExited;
        }

        private void KillPlayer()
        {
            if(_isKilled)
                return;
            
            _player.Decrease(1000);
            _isKilled = true;
        }

        private void OnTriggerExited(Collider collider)
        {
            if (!collider.gameObject.TryGetComponent(out IHealth health)) 
                return;
            
            _isPlayerInZone = false;
            _playerTimeInZone = 0;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (!collider.gameObject.TryGetComponent(out IHealth health))
                return;
            
            _isPlayerInZone = true;
            _player = health;
        }
    }
}