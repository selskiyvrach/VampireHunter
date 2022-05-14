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
        protected readonly IState Decorated;

        public DecoratorState(IState decorated = null) => 
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
        private readonly ITicker _ticker;

        public TickableState(IState decorated, ITicker ticker) : base(decorated) => 
            _ticker = ticker;

        public override void Enter(StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            _ticker.AddTickable(this);
        }

        public abstract void Tick(float deltaTime);

        public override void Dispose()
        {
            base.Dispose();
            _ticker.RemoveTickable(this);
        }
    }
    
    public class TransitionState : DecoratorState
    {
        protected readonly ITransition Transition;
        
        public TransitionState(IState decorated, ITransition transition) : base(decorated) => 
            Transition = transition;
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
    
    public class TaskAction : IAction
    {
        private readonly Task _task;

        public TaskAction(Task task) => 
            _task = task;

        public void Act() => 
            _task.Start();
    }
    
    public class TaskCompletedCondition : ICondition
    {
        private readonly Task _task;
        public TaskCompletedCondition(Task task) => 
            _task = task;

        public bool IsMet(StateMachine stateMachine) => 
            _task.IsCompleted;
    }

    public class TaskState : DecoratorState
    {
        public TaskState(Task task, IState decorated = null) : base(decorated)
        {
            decorated ??= new State();
            var taskAction = new TaskAction(task);
            var actionState = new ActionState(taskAction, decorated);
            decorated = actionState;
        }
    }

    public interface IStateBuilder : IFactory<IState>
    {
    }

    public abstract class StateBuilder : Factory<IState>, IStateBuilder 
    {
        
    }
}