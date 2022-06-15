using Selskiyvrach.VampireHunter.Model.Spreads;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IGunStats : IAimingSettings
    {
        float Damage { get; }
        float Recoil { get; }
        float CockTriggerTime { get; }
        float HipTime { get; }
        float ReloadTime { get; }
    }
}