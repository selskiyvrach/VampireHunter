using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.View;
using Ray = Selskiyvrach.Core.Maths.Ray;
using Vector2 = Selskiyvrach.Core.Maths.Vector2;

namespace Selskiyvrach.VampireHunter.Controller
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