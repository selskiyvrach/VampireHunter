using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;
using Selskiyvrach.VampireHunter.Gameplay.View.CreatureAnimations.Human;

namespace Selskiyvrach.VampireHunter.Gameplay.Mediator.CreatureAnimations.Humans
{
    public class HumanAnimatorMediator
    {
        private readonly IHumanAnimator _animator;

        public HumanAnimatorMediator(Human human, IHumanAnimator animator)
        {
            _animator = animator;
            human.OnBodyHit += PlayBodyHit;
            human.OnHeadHit += PlayHeadHit;
            human.OnDied += PlayDeath;
        }

        private void PlayDeath() => 
            _animator.PlayDeath();

        private void PlayHeadHit(HitInfo obj) => 
            _animator.PlayHeadHit();

        private void PlayBodyHit(HitInfo obj) => 
            _animator.PlayBodyHit();
    }
}