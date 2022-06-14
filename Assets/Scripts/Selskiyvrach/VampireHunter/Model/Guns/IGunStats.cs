namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IGunStats
    {
        float Damage { get; }
        float Accuracy { get; }
        float Recoil { get; }
        float AimTime { get; }
        float CockTriggerTime { get; }
        float HipTime { get; }
        float ReloadTime { get; }
    }
}