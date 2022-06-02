using System;
using UnityEngine;

namespace Selskiyvrach.Core.Maths
{
    public static class RightTriangle
    {
        public static float GetBase(float topAngleDegrees, float height)
        {
            var radians = Mathf.Deg2Rad * topAngleDegrees;
            var tan = Math.Tan(radians);
            return height * (float)tan;
        }
    }
}