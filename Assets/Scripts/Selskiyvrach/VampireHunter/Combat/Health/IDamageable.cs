using Selskiyvrach.VampireHunter.Combat.Weapons;

namespace Selskiyvrach.VampireHunter.Combat.Health
{
    public interface IDamageable
    {
        void TakeDamage(Damage damage);
    }
}