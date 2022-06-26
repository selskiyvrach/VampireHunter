using System.Collections.Generic;

namespace Selskiyvrach.VampireHunter.Gameplay.View.CreatureAnimations.Human
{
    public interface IHumanAnimatorSettings
    {
        IReadOnlyList<int> HeadHitHashes { get; }
        IReadOnlyList<int> BodyHitHashes { get; }
        IReadOnlyList<int> DeathHashes { get; }
    }
}