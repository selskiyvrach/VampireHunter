using Selskiyvrach.Core.Maths;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class TrajectoryCreator
    {
        private readonly ISight _sight;
        private readonly IBarrel _barrel;
        private readonly IRaycaster _raycaster;
        private readonly IAimingSettings _aimingSettings;

        public TrajectoryCreator(ISight sight, IBarrel barrel, IRaycaster raycaster, IAimingSettings aimingSettings)
        {
            _sight = sight;
            _barrel = barrel;
            _raycaster = raycaster;
            _aimingSettings = aimingSettings;
        }

        public Ray Create()
        {
            var ray = _sight.GetRayAffectedByAccuracy();
            var hit = _raycaster.Raycast(ray);
            if (hit.HasHit)
            {
                var direction = hit.HitPos - _barrel.ShootPoint;
                return new Ray(_barrel.ShootPoint, direction);
            }
            {
                var endPoint = ray.StartPos + ray.Direction * _aimingSettings.MaxDistance;
                var direction = endPoint - _barrel.ShootPoint;
                return new Ray(_barrel.ShootPoint, direction);
            }
        }
    }
}