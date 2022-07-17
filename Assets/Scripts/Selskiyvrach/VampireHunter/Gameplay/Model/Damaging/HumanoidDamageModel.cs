using System;
using Selskiyvrach.VampireHunter.Gameplay.Model.Limbs;
using UniRx;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public interface IDamageTakenNotifier
    {
        public abstract IObservable<DamageInfo> OnDamageTaken { get; }
    }

    public class HumanoidDamageModel : IDamageTakenNotifier
    {
        private readonly Limb _head;
        private readonly Limb _body;
        public IObservable<HitInfo> OnHeadHit => _head.OnHit;
        public IObservable<HitInfo> OnBodyHit => _body.OnHit;
        public IObservable<DamageInfo> OnDamageTaken { get; }

        public HumanoidDamageModel(Limb head, Limb body)
        {
            _head = head;
            _body = body;
            OnDamageTaken = _body.OnDamageTaken.Merge(_head.OnDamageTaken);
        }
    }
}