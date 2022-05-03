using Selskiyvrach.Core.Math;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.View;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class SightAdapter : ISight
    {
        private readonly ScreenPointAsRay _screenPointAsRay;

        public SightAdapter(ScreenPointAsRay screenPointAsRay)
        {
            _screenPointAsRay = screenPointAsRay;
        }

        public Ray GetPointingRay()
        {
            return _screenPointAsRay.GetRay().FromUnityToProject();
        }

        public Ray GetShotProjection()
        {
            return new Ray();
        }
    }
}