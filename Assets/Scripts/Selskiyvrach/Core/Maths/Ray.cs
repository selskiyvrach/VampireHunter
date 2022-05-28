using System;

namespace Selskiyvrach.Core.Maths
{
    public readonly struct Ray
    {
        public readonly Vector3 StartPos;
        public readonly Vector3 Direction;

        public Ray(Vector3 startPos, Vector3 direction)
        {
            StartPos = startPos;
            Direction = direction;
        }

        public Vector3 GetPoint(int distance)
        {
            if (distance <= 0)
                throw new ArgumentOutOfRangeException();
            return StartPos + Direction * distance;
        }
    }
}