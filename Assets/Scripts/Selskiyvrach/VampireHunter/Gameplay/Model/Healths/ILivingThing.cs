using System;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public interface ILivingThing : IHealthStatus
    {
        bool IsAlive { get; }
        event Action OnDied;
    }
}