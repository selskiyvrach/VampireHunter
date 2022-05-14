using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Combat
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
            Radius = height * Mathf.Tan((Mathf.Deg2Rad * (float)angle) / 2);
            BaseCenterPos = new Vector3(0, 0, (float) height);
        }

        public Ray GetRayOnSide(float angle)
        {
            var x = Radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = Radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            return new Ray(new Vector3(0,0,0), BaseCenterPos + new Vector3((float)x, (float)y, 0));
        }

        public Vector3 GetPointOnBaseCircle(float angle)
        {
            var x = Radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = Radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            return BaseCenterPos + new Vector3((float)x, (float)y, 0);
        }
    }
}