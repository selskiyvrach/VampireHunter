﻿using System;
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
        private readonly IAnimationCallback _shootAnimationCallback;
        private readonly IAnimationStarter _shootAnimationStarter;

        
        public bool IsCocked { get; private set; } = true;

        public Trigger(IAnimationStarter cockAnimationStarter, IAnimationCallback cockAnimationCallback, IAnimationStarter shootAnimationStarter, IAnimationCallback shootAnimationCallback)
        {
            _cockAnimationStarter = cockAnimationStarter;
            _cockAnimationCallback = cockAnimationCallback;
            _shootAnimationStarter = shootAnimationStarter;
            _shootAnimationCallback = shootAnimationCallback;
            _cockAnimationCallback.OnInvoked += OnAnimationEffectivelyFinished;
            _shootAnimationCallback.OnInvoked += OnShootAnimationFinished;

        }

        private void OnShootAnimationFinished()
        {
            IsCocked = false;
        }

        public void Cock() =>
            _cockAnimationStarter.StartAnimation();

        public void Pull() =>
            _shootAnimationStarter.StartAnimation();
        public void Dispose()
        {
            _cockAnimationCallback.OnInvoked -= OnAnimationEffectivelyFinished;
            _shootAnimationCallback.OnInvoked -= OnShootAnimationFinished;
        }

        private void OnAnimationEffectivelyFinished() =>
            IsCocked = true;
    }
}