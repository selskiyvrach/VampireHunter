using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }
        void TakeDamage(int damage);
    }
    
    public class Health : IDamageable, IHealthStatus, IHealth
    {
        private readonly IHealthSettings _healthSettings;
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public Health(IHealthSettings healthSettings)
        {
            _healthSettings = healthSettings;
            MaxHealth = CurrentHealth = healthSettings.MaxHealth;
        }

        public void TakeDamage(int damage) => 
            CurrentHealth -= damage;
    }
}