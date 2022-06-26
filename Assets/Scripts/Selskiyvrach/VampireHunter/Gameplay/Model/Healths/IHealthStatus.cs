using System;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public interface IHealthStatus
    {
        event Action OnHealthChanged;
        int CurrentHealth { get; }
        int MaxHealth { get; }
    }
}