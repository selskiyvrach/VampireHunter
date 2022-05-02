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
        private readonly IAnimationCallback _aimAnimationCallback;
        private readonly IAnimationCallback _idleAnimationCallback;
        private readonly IGunslingerInput _gunslingerInput;
        
        private bool _hasRecoil;
        private bool _idled;
        private bool _aimed;

        public Gunslinger(Gun gun,
            IAnimationStarter aimAnimationStarter,
            IAnimationCallback aimAnimationCallback,
            IAnimationStarter idleAnimationStarter,
            IAnimationCallback idleAnimationCallback,
            IAnimationStarter recoilAnimationStarter, 
            IAnimationCallback recoilAnimationCallback, 
            IGunslingerInput gunslingerInput)
        {
            _gun = gun;
            _aimAnimationCallback = aimAnimationCallback;
            _idleAnimationCallback = idleAnimationCallback;
            _recoilAnimationCallback = recoilAnimationCallback;
            _recoilAnimationCallback.OnInvoked += OnRecoilAnimationCompletedCallback;
            _aimAnimationCallback.OnInvoked += OnAimAnimationCompletedCallback;
            _idleAnimationCallback.OnInvoked += OnIdleAnimationCompletedCallback;
            _gunslingerInput = gunslingerInput;

            var stateBuilder = new StateBuilder();

            var idleState = stateBuilder
                .OnEnter(new DebugLogAction("idle"))
                .OnEnter(new ActionAction(idleAnimationStarter.StartAnimation))
                .OnExit(new ActionAction(() => _idled = false))
                .Build();
            stateBuilder.Reset();
            
            var cockTriggerState = stateBuilder
                .OnEnter(new DebugLogAction("cock"))
                .OnEnter(new ActionAction(_gun.CockTheTrigger))
                .Build();
            stateBuilder.Reset();
            
            var aimState = stateBuilder
                .OnEnter(new DebugLogAction("aim"))
                .OnEnter(new ActionAction(aimAnimationStarter.StartAnimation))
                .OnExit(new ActionAction(() => _aimed = false))
                .Build();
            stateBuilder.Reset();

            var shootState = stateBuilder
                .OnEnter(new DebugLogAction("shoot"))
                .OnEnter(new ActionAction(_gun.PullTheTrigger))
                .OnEnter(new ActionAction(() => _hasRecoil = true))
                .Build();
            stateBuilder.Reset();

            var recoilState = stateBuilder
                .OnEnter(new DebugLogAction("recoil"))
                .OnEnter(new ActionAction(_gun.AbsorbRecoil))
                .OnEnter(new ActionAction(recoilAnimationStarter.StartAnimation))
                .Build();
            stateBuilder.Reset();

            idleState.AddTransition(cockTriggerState, new CompositeConditionBuilder()
                .Add(new FuncCondition(() => !_gun.IsCocked))
                .Add(new FuncCondition(() => _idled))
                .Build());
            cockTriggerState.AddTransition(idleState, new FuncCondition(() => _gun.IsCocked));
            idleState.AddTransition(aimState, new FuncCondition(() => _gunslingerInput.ProceedShootingSequence() && _gun.IsCocked));
            aimState.AddTransition(shootState, new FuncCondition(() => _aimed && _gun.PointsAtTarget()));
            aimState.AddTransition(idleState, new FuncCondition(() => !_gunslingerInput.ProceedShootingSequence()));
            recoilState.AddTransition(idleState, new FuncCondition(() => !_hasRecoil));
            
            _stateMachine.StartState(idleState);
        }

        public void Tick(float deltaTime)
        {
            _gun.Tick(deltaTime);
            _stateMachine.Tick(deltaTime);
        }

        public void Dispose()
        {
            _recoilAnimationCallback.OnInvoked -= OnRecoilAnimationCompletedCallback;
            _aimAnimationCallback.OnInvoked -= OnAimAnimationCompletedCallback;
            _idleAnimationCallback.OnInvoked -= OnIdleAnimationCompletedCallback;
        }

        private void OnIdleAnimationCompletedCallback() =>
            _idled = true;

        private void OnAimAnimationCompletedCallback() =>
            _aimed = true;

        private void OnRecoilAnimationCompletedCallback() =>
            _hasRecoil = false;
    }
}