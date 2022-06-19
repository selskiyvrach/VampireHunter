using System;
using Selskiyvrach.VampireHunter.Model.Guns;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    /// <summary>
    /// Normalized value in range from maximum and minimum possible spread
    /// </summary>
    public readonly struct Accuracy
    {
        public float Value { get; }
        public float AsAngle { get; }

        public Accuracy(float value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));
            
            Value = value;
            AsAngle = Mathf.LerpAngle(AimingConstants.MinSpreadDegrees, AimingConstants.MaxSpreadDegrees, Value);
        }
    }
}