using System;

namespace CodeBase.Gameplay.PlayerSystem
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        event Action Dead;

        void Decrease(int value);
        void Increase(int value);
    }
}