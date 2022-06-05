using Selskiyvrach.Core.Maths;
using Sirenix.OdinInspector;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Selskiyvrach.Core.Unity.GizmosDrawers
{
    public class SpreadConeGizmos : GizmosDrawer
    {
        [SerializeField] private float _height;
        [SerializeField] private float _angle;
        [SerializeField] private int _sections = 10;
        [SerializeField] [ReadOnly] private float _actualAngle;

        public Cone Cone { get; private set; }

        protected override void Draw()
        {
            Cone = new Cone(_angle, _height);
            
            _actualAngle = Vector3.Angle(Cone.GetRayOnSide(0).direction, Cone.GetRayOnSide(180).direction);

            for (float i = 0; i < _sections; i++)
            {
                var startPoint = transform.position;
                var finalPoint = GetFinalPointForRay(i, Cone, startPoint);
                var nextFinalPoint = GetFinalPointForRay(i + 1, Cone, startPoint);
                Gizmos.DrawLine(finalPoint, nextFinalPoint);
                Gizmos.DrawLine(startPoint, finalPoint);
            }
        }

        private Vector3 GetFinalPointForRay(float i, Cone cone, Vector3 startPoint)
        {
            var angle = 360 - 360 * i / _sections;
            var point = cone.GetPointOnBaseCircle(angle);
            var finalPoint = startPoint + point;
            return finalPoint;
        }
    }
}