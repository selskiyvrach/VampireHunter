namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    /// <summary>
    /// Represents spread of a weapon measured in degrees
    /// </summary>
    public struct Spread
    {
        public float AngleDegrees { get; }

        public Spread(float angleDegrees) => 
            AngleDegrees = angleDegrees;
    }
}