﻿using System;
using System.Threading.Tasks;

namespace Selskiyvrach.Core.StateMachines
{
    public class State : IState              
    {
        protected StateMachine StateMachine;

        public virtual void Enter(StateMachine stateMachine) => 
            StateMachine = stateMachine;

        public virtual void Dispose()
        {
        }
    }

    public abstract class DecoratorState : State
    {
        protected internal IState Decorated;

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            Decorated?.Enter(stateMachine);
        }
    }
    
    public class ActionState : DecoratorState
    {
        protected IAction Action;

        public ActionState()
        {
        }

        public ActionState(System.Action action) => 
            Action = new ActionAction(action);

        public ActionState(IAction action) => 
            Action = action;

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            Action.Act();
        }

        public override void Dispose()
        {
            base.Dispose();
            Action.Dispose();
        }
    }
    
    public abstract class TickableState : DecoratorState, ITickable
    {
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

        public void Tick(float deltaTime) => 
            OnTick(deltaTime);

        protected abstract void OnTick(float deltaTime);
    }

    public interface ITickable
    {
        void Tick(float deltaTime);
    }

    public class TransitionState : TickableState
    {
        protected ITransition Transition;

        public TransitionState()
        {
        }

        public TransitionState(ITransition transition) => 
            Transition = transition;

        protected override void OnTick(float deltaTime) => 
            Transition.TryTransition(StateMachine);
    }

    public interface IThroughState
    {
        void OnComplete(IState state);
    }
    
    public class TaskAction : IAction
    {
        private readonly Func<Task> _taskSource;
        private Task _task;

        public bool IsFinished => _task != null && _task.IsCompleted; 

        public TaskAction(Func<Task> taskSource) => 
            _taskSource = taskSource;

        public void Act() => 
            _task = _taskSource.Invoke();

        public void Dispose()
        {
            _task?.Dispose();
            _task = null;
        }
    }
    
    public class TaskFinishedCondition : ICondition
    {
        private TaskAction _taskAction;

        public TaskFinishedCondition(TaskAction taskActions) => 
            _taskAction = taskActions;

        public bool IsMet(StateMachine stateMachine) => 
            _taskAction.IsFinished;
    }

    public class CompletableState : DecoratorState, IThroughState
    {
        private TransitionState _transitionState;
        
        public void OnComplete(IState state)
        {
            if(_transitionState != null)
                throw new InvalidOperationException();
            
            var transition = new Transition(state, GetCompletedCondition());
            _transitionState = new TransitionState(transition) {Decorated = this.Decorated};
            Decorated = _transitionState;
        }

        protected virtual ICondition GetCompletedCondition() => 
            new TrueCondition();
    }

    public class TaskState : CompletableState
    {
        private readonly TaskAction _taskAction;

        public TaskState(Func<Task> taskSource)
        {
            _taskAction = new TaskAction(taskSource);
            var taskState = new ActionState(_taskAction);
            Decorated = taskState;
        }

        protected override ICondition GetCompletedCondition() => 
            new TaskFinishedCondition(_taskAction);
    }
}