namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public interface IAimingSettings
    {
        float HipAccuracy { get; }
        float FromHipToAimedTime { get; }
        float FromAimedToHipTime { get; }
        float Accuracy { get; }
    }
}