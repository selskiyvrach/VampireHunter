using Selskiyvrach.Core.Physics;
using Selskiyvrach.VampireHunter.Model.Combat;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Characters
{
    public class Character : ICollidable<IBullet>
    {
        private readonly IHealth _health;

        public Character(IHealth health)
        {
            _health = health;
        }

        public void OnCollided(IBullet bullet)
        {
            _health.TakeDamage(bullet.Damage);                       
        }
    }
}