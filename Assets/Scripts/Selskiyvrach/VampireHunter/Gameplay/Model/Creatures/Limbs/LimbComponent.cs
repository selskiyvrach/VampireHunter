using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;
using Selskiyvrach.VampireHunter.Gameplay.Model.Healths;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures.Limbs
{
    public abstract class LimbComponent : BulletTargetComponent, ILimb
    {
        private IDamageable _health;
        private IDamageCoefficient _damageCoefficient;
     
        public void Construct(IDamageable health, IDamageCoefficient damageCoefficient)
        {
            _health = health;
            _damageCoefficient = damageCoefficient;
        }

        public override void GetHitBy(IBullet bullet)
        {
            _health.TakeDamage((int) (bullet.Damage * _damageCoefficient.Coefficient));
            RaiseOnHit(new HitInfo());
        }
    }
}