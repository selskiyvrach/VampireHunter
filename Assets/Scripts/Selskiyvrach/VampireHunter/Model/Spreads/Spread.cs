using System;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    
    /// <summary>
    /// Represents spread of a weapon measured in degrees
    /// </summary>
    public struct Spread
    {
        public float AngleDegrees { get; }

        public Spread(float angleDegrees)
        {
            if (angleDegrees > AimingConstants.MaxSpreadDegrees || angleDegrees < AimingConstants.MinSpreadDegrees)
                throw new ArgumentOutOfRangeException(nameof(angleDegrees));
            
            AngleDegrees = angleDegrees;
        }
    }
}