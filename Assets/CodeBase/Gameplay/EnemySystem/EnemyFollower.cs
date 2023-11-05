using System;
using System.Collections.Generic;
using CodeBase.Gameplay.PlayerSystem;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Gameplay.EnemySystem
{
    public class EnemyFollower : MonoBehaviour
    {
        private const float TargetStopDistance = 2f;
        private const float TargetRemainingDistance = 0.1f;
        private const float ChasePlayerDistance = 3f;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private bool _isBlocked;
        private float _speed;
        private Transform _target;
        private int _lastTargetIndex;
        private List<Transform> _points;
        private bool _targetChanged;
        private Player _player;
        private bool _isPlayerChasing;

        private void Start()
        {
            if (_points != null && _points.Count > 0)
            {
                _target = _points[_lastTargetIndex];
                _navMeshAgent.SetDestination(_target.position);
            }
        }

        private void Update()
        {
            if (_player == null)
                return;
            
            _isBlocked = Vector3.Distance(transform.position, _player.transform.position) < TargetStopDistance;
            
            if (_target == null || _isBlocked)
                return;

            if (!_isPlayerChasing)
                SetDefaultMovement();
            
            if (IsChasingPlayer())
            {
                _isPlayerChasing = true;
                return;
            }

            _isPlayerChasing = false;
        }

        private bool IsChasingPlayer()
        {
            var distance = Vector3.Distance(transform.position, _player.transform.position);

            if (distance <= ChasePlayerDistance)
            {
                _navMeshAgent.SetDestination(_player.transform.position);
                return true;
            }

            return false;
        }

        private void SetDefaultMovement()
        {
            switch (_navMeshAgent.remainingDistance)
            {
                case < TargetRemainingDistance when !_targetChanged:
                    _lastTargetIndex = (_lastTargetIndex + 1) % _points.Count;
                    _target = _points[_lastTargetIndex];
                    _navMeshAgent.SetDestination(_target.position);
                    _targetChanged = true;
                    break;
                case >= TargetRemainingDistance:
                    _targetChanged = false;
                    break;
            }
        }

        public void SetSpeed(float enemyDataSpeed)
        {
            _speed = enemyDataSpeed;
            _navMeshAgent.speed = enemyDataSpeed;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public void SetMovementPoints(List<Transform> points)
        {
            _points = points;
        }
    }
}