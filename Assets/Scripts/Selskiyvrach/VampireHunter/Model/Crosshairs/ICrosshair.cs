using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Crosshairs
{
    public interface ICrosshair
    {
        Ray GetCenterRay();
        Ray GetBulletTrajectory();
        float GetSpreadRadius();
    }

    public class Crosshair : ICrosshair
    {
        public Ray GetCenterRay()
        {
            return new Ray();// _screen.GetRayFromNormalizedPos(_settings.ScrosshairScreenPosNormalized);
        }

        public Ray GetBulletTrajectory()
        {
            // var screenSpreadMagnitude = GetSpreadRadius();
            // var centerPoint = _settings.ScrosshairScreenPosNormalized * _screen.ScreenSize;
            // var offset = _randomPointInCircle.GetPoint * screenSpreadMagnitude;
            // var startPointOnScreen = centerPoint + offset;
            // var startPointNormalized = startPointOnScreen /  _screen.ScreenSize;
            // return _screen.GetRayFromNormalizedPos(startPointNormalized);
            return new Ray();
        }

        public float GetSpreadRadius()
        {
            // var spreadHalf = RightTriangle.GetBase(_settings.MaxSpreadDegrees * (1 - (float)_statProvider.GetStat<Accuracy>().Value / (float)100) / 2,
            //     _settings.MaxDistance);
            // var fovTriangleBaseHalf = RightTriangle.GetBase(_screen.FieldOfViewDegrees / 2, _settings.MaxDistance);
            // var spreadToFOV = spreadHalf / fovTriangleBaseHalf;
            // var screenSpreadMagnitude = _screen.ScreenSize.Y * spreadToFOV;
            // return screenSpreadMagnitude;
            return default;
        }
    }
}
