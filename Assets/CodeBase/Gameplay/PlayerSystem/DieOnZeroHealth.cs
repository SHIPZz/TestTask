using System;
using UnityEngine;

namespace CodeBase.Gameplay.PlayerSystem
{
    [RequireComponent(typeof(IHealth))]
    public class DieOnZeroHealth : MonoBehaviour
    {
        private IHealth _health;

        private void Awake() => 
            _health = GetComponent<IHealth>();

        private void OnEnable() => 
            _health.Dead += OnDead;

        private void OnDisable() => 
            _health.Dead -= OnDead;

        private void OnDead() => 
            gameObject.SetActive(false);
    }
}