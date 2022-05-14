using System;

namespace Selskiyvrach.Core.Maths
{
    public readonly struct Cone
    {
        public readonly double Angle;
        public readonly double Radius;
        public readonly double Height;
        public readonly Vector3 BaseCenterPos;

        public Cone(double angle, double height)
        {
            Angle = angle;
            Height = height;
            Radius = height * Math.Tan(DegToRadConverter.DegToRad((float)angle) / 2);
            BaseCenterPos = new Vector3(0, 0, (float) height);
        }

        public Ray GetRayOnSide(float angle)
        {
            var x = Radius * Math.Cos(DegToRadConverter.DegToRad(angle));
            var y = Radius * Math.Sin(DegToRadConverter.DegToRad(angle));
            return new Ray(new Vector3(0,0,0), BaseCenterPos + new Vector3((float)x, (float)y, 0));
        }

        public Vector3 GetPointOnBaseCircle(float angle)
        {
            var x = Radius * Math.Cos(DegToRadConverter.DegToRad(angle));
            var y = Radius * Math.Sin(DegToRadConverter.DegToRad(angle));
            return BaseCenterPos + new Vector3((float)x, (float)y, 0);
        }
    }
}