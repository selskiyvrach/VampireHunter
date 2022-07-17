using System;
using Selskiyvrach.Core.Lifecycle;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;
using UniRx;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Limbs
{
    public abstract class Limb : LifecycleObject, IBulletTarget, IDamageTakenNotifier
    {
        private readonly IBulletTargetComponent _bulletTargetComponent;
        private readonly ILimbSettings _settings;
        
        private readonly Subject<HitInfo> _onHit = new Subject<HitInfo>();
        private readonly Subject<DamageInfo> _onDamageTaken = new Subject<DamageInfo>();

        public IObservable<HitInfo> OnHit => _onHit;
        public IObservable<DamageInfo> OnDamageTaken => _onDamageTaken;

        protected Limb(IBulletTargetComponent bulletTargetComponent, ILimbSettings settings)
        {
            _settings = settings;
            _bulletTargetComponent = bulletTargetComponent;
            _bulletTargetComponent.AddBulletTarget(this);
            AddLifecycleChild(_bulletTargetComponent);
        }

        public void GetHitBy(IBullet bullet)
        {
            var damage = bullet.Damage * _settings.DamageCoefficient;
            _onHit?.OnNext(new HitInfo(CalculateSeverity(damage)));
            _onDamageTaken?.OnNext(new DamageInfo(damage));
        }

        private HitSeverity CalculateSeverity(float damage) =>
            damage >= _settings.SevereDamageThreshold
                ? HitSeverity.Hard
                : HitSeverity.Regular;
    }
}