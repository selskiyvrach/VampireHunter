using Selskiyvrach.Core.Screen;
using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using Selskiyvrach.VampireHunter.Unity.Cameras;
using Ray = Selskiyvrach.Core.Maths.Ray;
using Vector2 = Selskiyvrach.Core.Maths.Vector2;

namespace Selskiyvrach.Core.Unity.Adapters
{
    public class ScreenPointToRayAdapter : IScreenPointToRay
    {
        private readonly ScreenPointAsRay _screenPointAsRay;

        public ScreenPointToRayAdapter(ScreenPointAsRay screenPointAsRay)
        {
            _screenPointAsRay = screenPointAsRay;
        }

        public Ray GetRayFromNormalizedPos(Vector2 screenPosNorm)
        {
            var ray = _screenPointAsRay.GetRay(screenPosNorm.ToUnity()).ToProject(); 
            return ray;
        }
    }
}