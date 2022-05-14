using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Unity.Cameras;
using UnityEngine;
using Vector2 = Selskiyvrach.Core.Maths.Vector2;

namespace Selskiyvrach.VampireHunter.Controller
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