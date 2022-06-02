using UnityEngine;

namespace Selskiyvrach.Core.Maths
{
    public readonly struct Cone
    {
        public float Angle { get; }
        public float Radius {get;}
        public float Height {get;}

        public Cone(float angle, float height)
        {
            Angle = angle;
            Height = height;
            Radius = height * Mathf.Tan((Mathf.Deg2Rad * angle) / 2);
        }

        public Ray GetRayOnSide(float angle)
        {
            var x = Radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = Radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            return new Ray(new Vector3(0,0,0), new Vector3(x, y, 0));
        }

        public Vector3 GetPointOnBaseCircle(float angle)
        {
            var x = Radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = Radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            return new Vector3(x, y, 0);
        }
    }
}