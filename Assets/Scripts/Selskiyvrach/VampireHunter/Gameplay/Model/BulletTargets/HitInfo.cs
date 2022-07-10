namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public struct HitInfo
    {
        public float Damage { get; }
        public HitSeverity Severity { get; }

        public HitInfo(float damage, HitSeverity severity)
        {
            Damage = damage;
            Severity = severity;
        }

        public enum HitSeverity
        {
            Regular,
            Hard
        }
    }
}