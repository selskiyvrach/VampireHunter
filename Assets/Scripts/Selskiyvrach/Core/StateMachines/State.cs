using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Selskiyvrach.Core.Factories;

namespace Selskiyvrach.Core.StateMachines
{
    public class State : IState
    {
        protected StateMachine StateMachine { get; private set; }

        public virtual void Enter(StateMachine stateMachine) => 
            StateMachine = stateMachine;

        public virtual void Dispose(){}
    }
    
    public class DecoratorState : State
    {
        public IState Decorated { get; protected set; }

        public DecoratorState()
        {
        }

        public DecoratorState(IState decorated) => 
            Decorated = decorated;

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            Decorated?.Enter(stateMachine);
        }

        public override void Dispose() => 
            Decorated?.Dispose();
    }
    

    public abstract class TickableState : DecoratorState, ITickable
    {
        protected TickableState(IState decorated = null) : base(decorated)
        {
        }

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            stateMachine.AddTickable(this);
        }

        public override void Dispose()
        {
            base.Dispose();
            StateMachine.RemoveTickable(this);
        }

        public abstract void Tick(float deltaTime);
    }
    
    public class TransitionState : TickableState
    {
        protected readonly ITransition Transition;
        
        public TransitionState(ITransition transition, IState decorated = null) : base(decorated) => 
            Transition = transition;

        public override void Tick(float deltaTime) => 
            Transition.TryTransition(StateMachine);
    }

    public class ActionState : DecoratorState
    {
        private readonly IAction _action;
        
        public ActionState(IAction action, IState decorated = null) : base(decorated) => 
            _action = action;

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            _action.Act();
        }
    }

    public interface IThroughState : IState
    {
        void OnComplete(IState state);
    }

    public class RightThroughState : DecoratorState, IThroughState
    {
        public RightThroughState(IState decorated = null) : base(decorated)
        {
            Decorated = new ThroughState(new TrueCondition());
        }

        public void OnComplete(IState state)
        {
            
        }
    }

    public class ThroughState : DecoratorState
    {
        private readonly ICondition _condition;

        public ThroughState(ICondition condition, IState decorated = null) : base(decorated) => 
            _condition = condition;

        public ThroughState OnComplete(IState state)
        {
            var transition = new Transition(state, _condition);
            Decorated = new TransitionState(transition);
            return this;
        }
    }

    public class DebugLogState : DecoratorState, IThroughState
    {
        private IState _onComplete;
        
        public DebugLogState(string message)=> 
            Decorated = new ActionState(new DebugLogAction(message));

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            if(_onComplete != null)
                stateMachine.StartState(_onComplete);
        }

        public void OnComplete(IState state) => 
            _onComplete = state;
    }

    public class TaskAction : IAction
    {
        private readonly Func<Task> _taskDelegate;
        private Task _task;
        public bool IsCompleted => _task?.IsCompleted ?? false;

        public TaskAction(Func<Task> taskDelegate) => 
            _taskDelegate = taskDelegate;

        public void Act() =>
            _task = _taskDelegate.Invoke();
    }
    
    public class TaskCompletedCondition : ICondition
    {
        private readonly TaskAction _taskAction;

        public TaskCompletedCondition(TaskAction taskAction) => 
            _taskAction = taskAction;

        public bool IsMet(StateMachine stateMachine) => 
            _taskAction.IsCompleted;
    }

    public class TaskState : DecoratorState, IThroughState
    {
        private readonly TaskAction _taskAction;
        private Transition _transition;

        public TaskState(Func<Task> taskDelegate, IState decorated = null) : base(decorated)
        {
            _taskAction = new TaskAction(taskDelegate);
            Decorated = new ActionState(_taskAction, decorated);
        }

        public void OnComplete(IState state)
        {
            if(_transition != null)
                throw new InvalidOperationException($"{nameof(OnComplete)} {nameof(_transition)} has already been assigned");

            _transition = new Transition(state, new TaskCompletedCondition(_taskAction));
            Decorated = new TransitionState(_transition, Decorated);
        }
    }

    public interface IStateBuilder : IFactory<IState>
    {
    }

    public abstract class StateBuilder : Factory<IState>, IStateBuilder 
    {
        
    }
}
