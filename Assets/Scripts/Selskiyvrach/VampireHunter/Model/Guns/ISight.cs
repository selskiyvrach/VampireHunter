using Selskiyvrach.Core;
using Selskiyvrach.Core.Maths;
using Selskiyvrach.Core.Screen;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using Selskiyvrach.VampireHunter.Model.Stats;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface ISight
    {
        Ray GetCenterRay();
        Ray GetBulletTrajectory();
        float GetSpreadRadius();
    }

    public class Sight : ISight
    {
        private readonly IStatProvider _statProvider;
        private readonly IAimingSettings _settings;
        private readonly IRandomPointInUnitCircleGenerator _randomPointInCircle;
        private readonly IScreen _screen;

        public Sight(
            IStatProvider statProvider,
            IAimingSettings settings, 
            IRandomPointInUnitCircleGenerator randomPointInCircle,
            IScreen screen) 
        {
            _statProvider = statProvider;
            _settings = settings;
            _randomPointInCircle = randomPointInCircle;
            _screen = screen;
        }
        public Ray GetCenterRay() => 
            _screen.GetRayFromNormalizedPos(_settings.ScrosshairScreenPosNormalized);

        public Ray GetBulletTrajectory()
        {
            var screenSpreadMagnitude = GetSpreadRadius();
            var centerPoint = _settings.ScrosshairScreenPosNormalized * _screen.ScreenSize;
            var offset = _randomPointInCircle.GetPoint * screenSpreadMagnitude;
            var startPointOnScreen = centerPoint + offset;
            var startPointNormalized = startPointOnScreen /  _screen.ScreenSize;
            return _screen.GetRayFromNormalizedPos(startPointNormalized);
        }

        public float GetSpreadRadius()
        {
            var spreadHalf = RightTriangle.GetBase(_settings.MaxSpreadDegrees * (1 - (float)_statProvider.GetStat<Accuracy>().Value / (float)100) / 2,
                _settings.MaxDistance);
            var fovTriangleBaseHalf = RightTriangle.GetBase(_screen.FieldOfViewDegrees / 2, _settings.MaxDistance);
            var spreadToFOV = spreadHalf / fovTriangleBaseHalf;
            var screenSpreadMagnitude = _screen.ScreenSize.Y * spreadToFOV;
            return screenSpreadMagnitude;
        }
    }
}
