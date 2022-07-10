using System;
using Selskiyvrach.VampireHunter.Gameplay.Mediator.GunViews;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;
using Selskiyvrach.VampireHunter.Gameplay.Model.Healths;
using UniRx;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public class HumanoidDamageModel : LifecycleObject
    {
        private readonly Head _head;
        private readonly Body _body;
        private readonly IHealth _health;
        private readonly IHumanoidDamageModelSettings _settings;
        private readonly Subject<HitInfo> _onHeadHit = new Subject<HitInfo>();
        private readonly Subject<HitInfo> _onBodyHit = new Subject<HitInfo>();

        public IObservable<HitInfo> OnHeadHit => _onHeadHit;
        public IObservable<HitInfo> OnBodyHit => _onBodyHit;

        public HumanoidDamageModel(Head head, Body body, IHealth health, IHumanoidDamageModelSettings settings)
        {
            _head = head;
            _body = body;
            _health = health;
            _settings = settings;
        }

        public override void Enable()
        {
            base.Enable();
            StageForDisableWithThis(_head.OnHit.Subscribe(HeadHitReceived));
            StageForDisableWithThis(_body.OnHit.Subscribe(BodyHitReceived));
        }

        private void BodyHitReceived(IBullet bullet)
        {
            var damage = bullet.Damage * _settings.BodyDamageCoefficient;
            _health.TakeDamage(damage);
            var severity = GetSeverity(damage);
            _onBodyHit?.OnNext(new HitInfo(severity));
        }

        private void HeadHitReceived(IBullet bullet)
        {
            var damage = bullet.Damage * _settings.HeadDamageCoefficient;
            _health.TakeDamage(damage);
            var severity = GetSeverity(damage);
            _onHeadHit?.OnNext(new HitInfo(severity));
        }

        private HitInfo.Severity GetSeverity(float damage) =>
            damage >= _health.MaxHealth
                ? HitInfo.Severity.Heavy
                : HitInfo.Severity.Light;
    }
}