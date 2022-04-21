using System;
using Selskiyvrach.VampireHunter.Combat.Weapons;

namespace Selskiyvrach.VampireHunter.Combat.Health
{
    public class Health : IDamageable
    {
        private float _maxHp;
        private float _currHp;

        public event Action OnDied;

        public Health(float maxHp)
        {
            _maxHp = maxHp;
        }

        public void TakeDamage(Damage damage)
        {
            _currHp -= damage.Value;
            
            if(_currHp > 0)
                return;
            
            _currHp = 0;
            OnDied?.Invoke();
        }
    }
}