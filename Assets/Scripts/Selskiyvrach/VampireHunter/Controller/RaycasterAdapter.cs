using Selskiyvrach.Core.Math;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.View;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class RaycasterAdapter : IRaycaster
    {
        private readonly Raycaster _raycaster;

        public RaycasterAdapter(Raycaster raycaster)
        {
            _raycaster = raycaster;
        }

        public bool Raycast(Ray ray)
        {
            return _raycaster.Raycast(
                new UnityEngine.Ray(
                    new UnityEngine.Vector3(ray.StartPos.X, ray.StartPos.Y, ray.StartPos.Z),
                    new UnityEngine.Vector3(ray.Direction.X, ray.Direction.Y, ray.Direction.Z)));
        }
    }
}