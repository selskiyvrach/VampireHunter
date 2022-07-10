using Selskiyvrach.VampireHunter.Gameplay.Mediator.GunViews;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using UniRx;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public abstract class Limb : LifecycleObject, IBulletTarget
    {
        private readonly IBulletTargetComponent _bulletTargetComponent;
        private readonly Subject<IBullet> _onHit = new Subject<IBullet>();

        public Subject<IBullet> OnHit => _onHit;
        
        protected Limb(IBulletTargetComponent bulletTargetComponent) => 
            _bulletTargetComponent = bulletTargetComponent;

        public void GetHitBy(IBullet bullet) => 
            _onHit?.OnNext(bullet);

        public override void Enable()
        {
            base.Enable();
            _bulletTargetComponent.AddBulletTarget(this);
            _bulletTargetComponent.Enable();
        }

        public override void Disable()
        {
            base.Disable();
            _bulletTargetComponent.RemoveBulletTarget(this);
            _bulletTargetComponent.Disable();
        }
    }
    
    public class Head : Limb
    {
        public Head(IBulletTargetComponent bulletTargetComponent) : base(bulletTargetComponent)
        {
        }
    }

    public class Body : Limb
    {
        public Body(IBulletTargetComponent bulletTargetComponent) : base(bulletTargetComponent)
        {
        }
    }
}