using Selskiyvrach.Core.Maths;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Unity.Combat;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class AimingSettingsAdapter : IAimingSettings
    {
        private readonly AimingSettings _settings;

        public AimingSettingsAdapter(AimingSettings settings)
        {
            _settings = settings;
        }

        public Vector2 ScrosshairScreenPosNormalized => _settings.CrosshairScreenPosNormalized.ToProject();
        public int MaxDistance => _settings.MaxAimingDistance;
        public int MaxSpreadDegrees => _settings.MaxSpreadDegrees;
    }
}