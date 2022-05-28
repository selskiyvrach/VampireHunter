using Selskiyvrach.Core.Screen;
using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using Selskiyvrach.VampireHunter.Unity.Cameras;
using Vector2 = Selskiyvrach.Core.Maths.Vector2;

namespace Selskiyvrach.Core.Unity.Adapters
{
    public class ScreenSizeAdapter : IScreenSize
    {
        private readonly ScreenSizePixels _screenSizePixels;

        public ScreenSizeAdapter(ScreenSizePixels screenSizePixels)
        {
            _screenSizePixels = screenSizePixels;
        }

        public Vector2 ScreenSize => _screenSizePixels.ScreenSize.ToProject();
    }
}