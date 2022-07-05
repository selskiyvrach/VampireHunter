namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public interface IHealthStatus
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }
    }
}