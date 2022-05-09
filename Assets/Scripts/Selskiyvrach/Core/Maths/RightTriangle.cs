using System;

namespace Selskiyvrach.Core.Maths
{
    public static class RightTriangle
    {
        public static float GetBase(float topAngleDegrees, float height)
        {
            var radians = DegToRadConverter.DegToRad(topAngleDegrees);
            var tan = Math.Tan(radians);
            return (float)height * (float)tan;
        }
    }
}