namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IGunStats : IAimingSettings, IMagazineSettings
    {
        float Damage { get; }
        float Recoil { get; }
        float CockTriggerTime { get; }
        float HipTime { get; }
        float ReloadTime { get; }
    }
}