namespace Selskiyvrach.VampireHunter.Gameplay.Model
{
    public class AimingConstants
    {
        public static int MaxSpreadDegrees { get; private set; }
        public static int MinSpreadDegrees { get; private set;}
        public static int MaxAimingDistance { get; private set;}

        public AimingConstants(int maxSpreadDegrees, int minSpreadDegrees, int maxAimingDistance)
        {
            MaxSpreadDegrees = maxSpreadDegrees;
            MinSpreadDegrees = minSpreadDegrees;
            MaxAimingDistance = maxAimingDistance;
        }
    }
}