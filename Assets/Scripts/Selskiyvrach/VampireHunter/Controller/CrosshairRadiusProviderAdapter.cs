using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Unity.Combat;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class CrosshairRadiusProviderAdapter : ICrosshairRadius
    {
        private readonly ISight _sight;

        public CrosshairRadiusProviderAdapter(ISight sight)
        {
            _sight = sight;
        }

        public float Radius => _sight.GetSpreadRadius();
    }
}