using System;
using UnityEngine;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        public int CurrentHealth { get; private set; }

        public int MaxHealth { get; private set; }

        public event Action Dead; 

        private void Awake()
        {
            MaxHealth = CurrentHealth;
        }

        public void Decrease(int value)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - value, 0, MaxHealth);
            
            if(CurrentHealth == 0)
                Dead?.Invoke();
        }

        public void Increase(int value)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, MaxHealth);
        }
    }
}