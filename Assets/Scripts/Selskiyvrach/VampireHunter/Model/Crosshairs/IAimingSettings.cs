using Selskiyvrach.Core.Maths;

namespace Selskiyvrach.VampireHunter.Model.Crosshairs
{
    public interface IAimingSettings
    {
        Vector2 ScrosshairScreenPosNormalized { get; }
        int MaxDistance { get; }
        int MaxSpreadDegrees { get; }
    }
}