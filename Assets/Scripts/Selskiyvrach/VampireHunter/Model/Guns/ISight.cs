using Selskiyvrach.Core.Maths;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IPointer
    {
        Ray GetPerfectlyAccurateRay();
    }
    
    public interface ISight : IPointer
    {
        Ray GetRayAffectedByAccuracy();
        float GetSpreadRadius();
    }
    
    public class Sight : ISight
    {
        private readonly IScreenPointToRay _screenPointToRay;
        private readonly IScreenSize _screenSize;
        private readonly IAimingSettings _settings;
        private readonly IRandomPointInUnitCircleGenerator _randomPointInCircle;
        private readonly IVerticalFieldOfView _fieldOfView;
        private readonly IAccuracyProvider _accuracyProvider;
        public Sight(
            IScreenPointToRay screenPointToRay, 
            IScreenSize screenSize, 
            IAimingSettings settings, 
            IRandomPointInUnitCircleGenerator randomPointInCircle, 
            IVerticalFieldOfView fieldOfView, IAccuracyProvider accuracyProvider)
        {
            _screenPointToRay = screenPointToRay;
            _screenSize = screenSize;
            _settings = settings;
            _randomPointInCircle = randomPointInCircle;
            _fieldOfView = fieldOfView;
            _accuracyProvider = accuracyProvider;
        }

        public Ray GetPerfectlyAccurateRay() =>
            _screenPointToRay.GetRayFromNormalizedPos(_settings.ScrosshairScreenPosNormalized);

        public Ray GetRayAffectedByAccuracy()
        {
            var screenSpreadMagnitude = GetSpreadRadius();
            var centerPoint = _settings.ScrosshairScreenPosNormalized * _screenSize.ScreenSize;
            var offset = _randomPointInCircle.GetPoint * screenSpreadMagnitude;
            var startPointOnScreen = centerPoint + offset;
            var startPointNormalized = startPointOnScreen / _screenSize.ScreenSize;
            return _screenPointToRay.GetRayFromNormalizedPos(startPointNormalized);
        }

        public float GetSpreadRadius()
        {
            var spreadHalf = RightTriangle.GetBase(_settings.MaxSpreadDegrees * (1 - _accuracyProvider.Accuracy.Normalized) / 2,
                _settings.MaxDistance);
            var fovTriangleBaseHalf = RightTriangle.GetBase(_fieldOfView.FieldOfViewDegrees / 2, _settings.MaxDistance);
            var spreadToFOV = spreadHalf / fovTriangleBaseHalf;
            var screenSpreadMagnitude = _screenSize.ScreenSize.Y * spreadToFOV;
            return screenSpreadMagnitude;
        }
    }

    public interface IAccuracyProvider
    {
        Accuracy Accuracy { get; }
    }


    public interface IAimingSettings
    {
        Vector2 ScrosshairScreenPosNormalized { get; }
        int MaxDistance { get; }
        int MaxSpreadDegrees { get; }
    }

    public interface IScreenSize
    {
        Vector2 ScreenSize { get; }
    }

    public interface IScreenPointToRay
    {
        Ray GetRayFromNormalizedPos(Vector2 screenPosNorm);
    }

    public interface IRandomPointInUnitCircleGenerator
    {
        Vector2 GetPoint { get; }
    }

    public interface IVerticalFieldOfView
    {
        float FieldOfViewDegrees { get; }
    }

    public readonly struct Accuracy
    {
        public readonly int Value;
        public readonly float Normalized;

        public Accuracy(int value)
        {
            Value = value;
            Normalized = (float)Value / 100f;
        }
    }
}
