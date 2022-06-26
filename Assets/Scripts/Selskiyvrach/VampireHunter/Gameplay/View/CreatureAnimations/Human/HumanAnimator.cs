using System.Collections.Generic;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.View.CreatureAnimations.Human
{
    public class HumanAnimator : IHumanAnimator
    {
        private readonly Animator _animator;
        private readonly IHumanAnimatorSettings _settings;
 
        public HumanAnimator(Animator animator, IHumanAnimatorSettings settings)
        {
            _animator = animator;
            _settings = settings;
        }

        public void PlayHeadHit() => 
            _animator.SetTrigger(RandomElement(_settings.HeadHitHashes));

        public void PlayBodyHit() => 
            _animator.SetTrigger(RandomElement(_settings.BodyHitHashes));

        public void PlayDeath() => 
            _animator.SetTrigger(RandomElement(_settings.DeathHashes));

        private int RandomElement(IReadOnlyList<int> source) => 
            source[Random.Range(0, source.Count - 1)];
    }
}