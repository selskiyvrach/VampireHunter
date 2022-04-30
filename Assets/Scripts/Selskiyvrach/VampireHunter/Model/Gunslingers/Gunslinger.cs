using System;
using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger : ITickable, IDisposable
    {
        private readonly StateMachine _stateMachine = new StateMachine();
        private readonly Gun _gun;
        private readonly IAnimationCallback _recoilAnimationCallback;
        
        private bool _hasRecoil;

        public Gunslinger(Gun gun, 
            IAnimationStarter recoilAnimationStarter, 
            IAnimationCallback recoilAnimationCallback)
        {
            _gun = gun;
            _recoilAnimationCallback = recoilAnimationCallback;
            _recoilAnimationCallback.OnInvoked += OnRecoilAnimationCompletedCallback;

            var stateBuilder = new StateBuilder();

            var idleState = stateBuilder.Build();
            stateBuilder.Reset();
            
            var cockTriggerState = stateBuilder
                .OnEnter(new ActionAction(_gun.CockTheTrigger))
                .Build();
            stateBuilder.Reset();
            
            var aim = stateBuilder
                .Build();
            stateBuilder.Reset();

            var shootState = stateBuilder
                .OnEnter(new ActionAction(_gun.PullTheTrigger))
                .OnEnter(new ActionAction(() => _hasRecoil = true))
                .Build();
            stateBuilder.Reset();

            var recoilState = stateBuilder
                .OnEnter(new ActionAction(_gun.AbsorbRecoil))
                .OnEnter(new ActionAction(recoilAnimationStarter.StartAnimation))
                .Build();
            stateBuilder.Reset();
        }

        public void Tick(float deltaTime)
        {
            _stateMachine.Tick(deltaTime);
            _gun.Tick(deltaTime);
        }

        public void Dispose() =>
            _recoilAnimationCallback.OnInvoked -= OnRecoilAnimationCompletedCallback;

        private void OnRecoilAnimationCompletedCallback() =>
            _hasRecoil = false;
    }
}