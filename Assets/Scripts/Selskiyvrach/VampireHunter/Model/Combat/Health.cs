using System;

namespace Selskiyvrach.VampireHunter.Model.Combat
{
    public interface IHealth : IDamageable
    {
        float CurrentPoints { get; }
        float MaxPoints { get; }
    }

    public class OnDiedCallbackDispatcher : IHealth 
    {
        private readonly IHealth _decorated;

        public event Action OnDied;
        public float CurrentPoints => _decorated.CurrentPoints;
        public float MaxPoints => _decorated.MaxPoints;

        public OnDiedCallbackDispatcher(IHealth decorated)
        {
            _decorated = decorated;
        }
        public void TakeDamage(Damage damage)
        {
            _decorated.TakeDamage(damage);
            if(_decorated.CurrentPoints == 0)
                OnDied?.Invoke();
        }
    }

    public class Damage
    {
        public float Value { get; }
        
        public Damage(float value) => 
            Value = value;
    }

    public interface IDamageable
    {
        void TakeDamage(Damage damage);
    }

    public class Health : IHealth
    {
        public float CurrentPoints { get; private set; }
        public float MaxPoints { get; }
        
        public Health(int maxPoints)
        {
            MaxPoints = maxPoints;
            CurrentPoints = maxPoints;
        }

        public void TakeDamage(Damage damage)
        {
            CurrentPoints -= damage.Value;
            if (CurrentPoints < 0)
                CurrentPoints = 0;
        }
    }
}