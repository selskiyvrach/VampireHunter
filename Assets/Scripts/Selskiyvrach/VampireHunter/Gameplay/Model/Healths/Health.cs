using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public class Health : IDamageable
    {
        private readonly IHealthSettings _healthSettings;

        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public Health(IHealthSettings healthSettings)
        {
            _healthSettings = healthSettings;
            MaxHealth = CurrentHealth = healthSettings.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            
            if (CurrentHealth < 0)
                CurrentHealth = 0;
        }
    }
}