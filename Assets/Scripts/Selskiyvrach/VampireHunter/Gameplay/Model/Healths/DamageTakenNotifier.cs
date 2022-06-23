using System;
using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    public class DamageTakenNotifier : IDamageable
    {
        private readonly IDamageable _decorated;
        public event Action<int> OnDamageTaken;

        public DamageTakenNotifier(IDamageable decorated) => 
            _decorated = decorated;

        public void TakeDamage(int damage)
        {
            _decorated.TakeDamage(damage);
            OnDamageTaken?.Invoke(damage);
        }
    }
}