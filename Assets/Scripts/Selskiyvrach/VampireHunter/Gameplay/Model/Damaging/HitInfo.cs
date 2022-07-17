using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public readonly struct HitInfo
    {
        public HitSeverity Severity { get; }

        public HitInfo(HitSeverity severity) => 
            Severity = severity;
    }
}