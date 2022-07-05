using System;
using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures.Limbs
{

    public class DamageModel
    {
        private readonly HashSet<ILimb> _limbs = new HashSet<ILimb>();

        public DamageModel(params ILimb[] limbs)
        {
            foreach (var limb in limbs)
                _limbs.Add(limb);
        }
    }

    public class Head : Limb
    {
        public Head(IDamageable health, IDamageCoefficient damageCoefficient, IBulletTargetComponent bulletTargetComponent) : base(health, damageCoefficient, bulletTargetComponent)
        {
        }
    }
    
    public class Body : Limb
    {
        public Body(IDamageable health, IDamageCoefficient damageCoefficient, IBulletTargetComponent bulletTargetComponent) : base(health, damageCoefficient, bulletTargetComponent)
        {
        }
    }

    public abstract class AnyLimbHitListener
    {
    }

    public class HeadHitListener
    {
    }

    public abstract class Limb : ILimb
    {
        private readonly IDamageable _health;
        private readonly IDamageCoefficient _damageCoefficient;
        private readonly IBulletTargetComponent _bulletTargetComponent;

        protected Limb(IDamageable health, IDamageCoefficient damageCoefficient, IBulletTargetComponent bulletTargetComponent)
        {
            _health = health;
            _damageCoefficient = damageCoefficient;
            _bulletTargetComponent = bulletTargetComponent;
        }

        public void GetHitBy(IBullet bullet) => 
            _health.TakeDamage((int) (bullet.Damage * _damageCoefficient.Coefficient));

        public void Enable()
        {
            _bulletTargetComponent.AddBulletTarget(this);
            _bulletTargetComponent.Enable();
        }

        public void Disable()
        {
            _bulletTargetComponent.RemoveBulletTarget(this);
            _bulletTargetComponent.Disable();
        }
    }
}