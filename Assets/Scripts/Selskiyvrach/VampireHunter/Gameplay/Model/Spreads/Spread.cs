namespace Selskiyvrach.VampireHunter.Gameplay.Model.Spreads
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