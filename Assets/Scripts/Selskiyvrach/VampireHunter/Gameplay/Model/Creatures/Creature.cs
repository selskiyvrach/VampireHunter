using System;
using Selskiyvrach.Core.Unity.Transforms;
using Selskiyvrach.VampireHunter.Gameplay.Model.Healths;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public interface ICreature : IMover, ILooker, IHealthStatus, ITransformable, IAlive
    {
    }

    public interface IAlive
    {
        event Action OnDied;
        bool Alive { get; }
    }
}