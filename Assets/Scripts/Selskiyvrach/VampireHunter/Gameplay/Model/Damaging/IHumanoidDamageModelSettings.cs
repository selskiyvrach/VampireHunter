namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public interface IHumanoidDamageModelSettings
    {
        float HeadDamageCoefficient { get; }
        float BodyDamageCoefficient { get; }
        float SevereHeadDamageThreshold { get; set; }
        float SevereBodyDamageThreshold { get; set; }
    }
}