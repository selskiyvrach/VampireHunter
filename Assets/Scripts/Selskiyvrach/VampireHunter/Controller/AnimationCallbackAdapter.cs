using System;
using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.View;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class AnimationCallbackAdapter : IAnimationCallback, IDisposable
    {
        private readonly AnimationCallbackReceiver _animationCallback;
        
        public event Action OnInvoked;

        public AnimationCallbackAdapter(AnimationCallbackReceiver animationCallback)
        {
            _animationCallback = animationCallback;
            _animationCallback.OnInvoked += OnDecoratedInvoked;
        }

        public void Dispose() => 
            _animationCallback.OnInvoked -= OnDecoratedInvoked;
        private void OnDecoratedInvoked() 
            => OnInvoked?.Invoke();
    }
}