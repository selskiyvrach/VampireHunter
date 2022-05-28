using Selskiyvrach.VampireHunter.Unity.Combat;
using ISight = Selskiyvrach.VampireHunter.Model.Guns.ISight;

namespace Selskiyvrach.VampireHunter.Controller.Guns
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