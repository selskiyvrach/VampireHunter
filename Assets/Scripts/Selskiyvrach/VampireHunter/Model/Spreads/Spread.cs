namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    public struct Spread
    {
        public float AngleDegrees { get; }

        public Spread(float angleDegrees) => 
            AngleDegrees = angleDegrees;
    }
}