using System;
using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public class OnDiedNotifier : IDamageable
    {
        private readonly Health _decorated;
        public event Action OnDied;

        public OnDiedNotifier(Health decorated) => 
            _decorated = decorated;

        public void TakeDamage(int damage)
        {
            _decorated.TakeDamage(damage);
            if (_decorated.CurrentHealth == 0)
                OnDied?.Invoke();
        }
    }
}