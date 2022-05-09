using System;

namespace Selskiyvrach.Core.Maths
{
    public static class DegToRadConverter
    {
        public static double DegToRad(float degrees)
        {
            return Math.PI / 180f * degrees;
        }

        public static double RadToDeg(float radians)
        {
            return radians / (Math.PI / 180f);
        }
    }
}