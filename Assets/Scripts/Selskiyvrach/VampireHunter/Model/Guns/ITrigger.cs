using System;
using Selskiyvrach.VampireHunter.Model.Animations;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface ITrigger
    {
        bool IsCocked { get; }
        void Cock();
        void Pull();
    }
    
    public class Trigger : ITrigger, IDisposable
    {
        private readonly IAnimationCallback _cockAnimationCallback;
        private readonly IAnimationStarter _cockAnimationStarter;
        
        public bool IsCocked { get; private set; } = true;

        public Trigger(IAnimationStarter cockAnimationStarter, IAnimationCallback cockAnimationCallback)
        {
            _cockAnimationStarter = cockAnimationStarter;
            _cockAnimationCallback = cockAnimationCallback;
            _cockAnimationCallback.OnInvoked += OnAnimationEffectivelyFinished;
        }

        public void Cock() =>
            _cockAnimationStarter.StartAnimation();

        public void Pull() =>
            IsCocked = false;

        public void Dispose() =>
            _cockAnimationCallback.OnInvoked -= OnAnimationEffectivelyFinished;

        private void OnAnimationEffectivelyFinished() =>
            IsCocked = true;
    }
}