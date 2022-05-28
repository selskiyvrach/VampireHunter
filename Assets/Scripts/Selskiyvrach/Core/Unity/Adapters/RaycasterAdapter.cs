using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Unity.Collisions;
using Ray = Selskiyvrach.Core.Maths.Ray;

namespace Selskiyvrach.Core.Unity.Adapters
{
    public class RaycasterAdapter : IRaycaster
    {
        private readonly Raycaster _raycaster;

        public RaycasterAdapter(Raycaster raycaster)
        {
            _raycaster = raycaster;
        }

        public RaycastResult Raycast(Ray ray, float maxDist)
        {
            var unityResult = _raycaster.Raycast<BulletTarget>(ray.ToUnity(), maxDist);
            return new RaycastResult(unityResult.HasHit, unityResult.Point.ToProject());
        }
    }
}