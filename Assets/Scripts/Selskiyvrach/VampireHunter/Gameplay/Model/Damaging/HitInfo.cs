namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public struct HitInfo
    {
        public Severity HitSeverity { get; }

        public HitInfo(Severity severity) => 
            HitSeverity = severity;

        public enum Severity
        {
            Light,
            Heavy
        }
    }
}