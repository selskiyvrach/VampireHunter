using Selskiyvrach.Core.Screen;
using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using Selskiyvrach.VampireHunter.Unity.Cameras;
using Ray = Selskiyvrach.Core.Maths.Ray;
using Vector2 = Selskiyvrach.Core.Maths.Vector2;

namespace Selskiyvrach.Core.Unity.Adapters
{
    public class ScreenAdapter : IScreen
    {
        private readonly ScreenPointAsRay _screenPointAsRay;
        private readonly CamFieldOfView _fieldOfView;
        private readonly ScreenSizePixels _screenSizePixels;

        public float FieldOfViewDegrees => _fieldOfView.FieldOfView;
        public Vector2 ScreenSize => _screenSizePixels.ScreenSize.ToProject();
        
        public ScreenAdapter(ScreenPointAsRay screenPointAsRay, CamFieldOfView fieldOfView, ScreenSizePixels screenSizePixels)
        {
            _screenPointAsRay = screenPointAsRay;
            _fieldOfView = fieldOfView;
            _screenSizePixels = screenSizePixels;
        }

        public Ray GetRayFromNormalizedPos(Vector2 screenPosNorm) => 
            _screenPointAsRay.GetRay(screenPosNorm.ToUnity()).ToProject();
    }
}