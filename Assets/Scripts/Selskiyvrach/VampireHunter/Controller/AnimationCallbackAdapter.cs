using System;
using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Unity.Animations;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class AnimationCallbackAdapter : IAnimationCallback, IDisposable
    {
        private readonly ICallback _animationCallback;
        
        public event Action OnInvoked;

        public AnimationCallbackAdapter(ICallback animationCallback)
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