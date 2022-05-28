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
        private readonly IGun _gun;
        private readonly IGunslingerInput _gunslingerInput;
        
        public Gunslinger(IGun gun, IGunslingerInput gunslingerInput)
        {
            _gun = gun;
            _gunslingerInput = gunslingerInput;
                        
        }

        public void Tick(float deltaTime) => 
            _stateMachine.Tick(deltaTime);

        public void Dispose()
        {
        }
    }

    public class StartAnimationState : CompletableState
    {
        private readonly IAnimationStarter _animationStarter;

        public StartAnimationState(IAnimationStarter animationStarter) => 
            _animationStarter = animationStarter;

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            _animationStarter.StartAnimation();
        }
    }

    public class PlayAnimationToTheEndState : StartAnimationState
    {
        private readonly AnimationFinishedCondition _animationFinishedCondition;
        public PlayAnimationToTheEndState(IAnimationStarter animationStarter, IAnimationCallback animationCallback) : base(animationStarter) => 
            _animationFinishedCondition = new AnimationFinishedCondition(animationCallback);

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            _animationFinishedCondition.Reset();
        }

        public override void Dispose()
        {
            base.Dispose();
            _animationFinishedCondition.Reset();
        }

        protected override ICondition GetCompletedCondition() => 
            _animationFinishedCondition;
    }
    
    public class AnimationFinishedCondition : ICondition
    {
        private readonly IAnimationCallback _animationCallback;
        private bool _finished;

        public AnimationFinishedCondition(IAnimationCallback animationCallback) => 
            _animationCallback = animationCallback;

        public void Reset() => 
            _finished = false;

        public bool IsMet(StateMachine stateMachine) => 
            _finished;
    }

    public class CockTriggerState : CompletableState
    {
        private readonly ITrigger _trigger;

        public CockTriggerState(ITrigger trigger)
        {
            _trigger = trigger;
            Decorated = new ActionState(() => _trigger.Cock()){Decorated = Decorated};
        }
    }

    public class StartCockingState : PlayAnimationToTheEndState
    {
        public StartCockingState(IAnimationStarter animationStarter, IAnimationCallback animationCallback) : base(animationStarter, animationCallback)
        {
        }
    }

    public class IdleState : DecoratorState
    {
        public IdleState(IAnimationStarter idleAnimationStarter) => 
            Decorated = new StartAnimationState(idleAnimationStarter);
    }
}