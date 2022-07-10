using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public interface IHealth
    {
        float CurrentHealth { get; }
        int MaxHealth { get; }
        void TakeDamage(float damage);
    }
    
    public class Health : IHealth
    {
        private readonly IHealthSettings _healthSettings;
        public float CurrentHealth { get; private set; }

        public int MaxHealth { get; }

        public Health(IHealthSettings healthSettings)
        {
            _healthSettings = healthSettings;
            MaxHealth = healthSettings.MaxHealth;
            CurrentHealth = healthSettings.MaxHealth;
        }

        public void TakeDamage(float damage) => 
            CurrentHealth -= damage;
    }
}