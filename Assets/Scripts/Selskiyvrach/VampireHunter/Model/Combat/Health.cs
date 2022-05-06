using System;

namespace Selskiyvrach.VampireHunter.Model.Combat
{
    public interface IHealth : IDamageable
    {
        int CurrentPoints { get; }
        int MaxPoints { get; }
    }

    public class OnDiedCallbackDispatcher : IHealth 
    {
        private readonly IHealth _decorated;

        public event Action OnDied;
        public int CurrentPoints => _decorated.CurrentPoints;
        public int MaxPoints => _decorated.MaxPoints;

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

    public interface IDamageable
    {
        void TakeDamage(Damage damage);
    }

    public class Health : IHealth
    {
        public int CurrentPoints { get; private set; }
        public int MaxPoints { get; }
        
        public Health(int maxPoints)
        {
            MaxPoints = maxPoints;
            CurrentPoints = maxPoints;
        }

        public void TakeDamage(Damage damage)
        {
            CurrentPoints -= damage.Amount;
            if (CurrentPoints < 0)
                CurrentPoints = 0;
        }
    }

    public readonly struct Damage
    {
        public readonly int Amount;

        public Damage(int amount)
        {
            if(amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            Amount = amount;
        }
    }
}