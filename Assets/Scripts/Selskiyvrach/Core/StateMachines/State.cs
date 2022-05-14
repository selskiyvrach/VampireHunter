namespace Selskiyvrach.Core.StateMachines
{
    public abstract class State : IState
    {
        public abstract void Enter(StateMachine stateMachine);
        public virtual void Dispose(){}
    }
    
    public class DecoratorState : IState
    {
        private readonly IState _state;

        public DecoratorState(IState state) => 
            _state = state;

        public virtual void Enter(StateMachine stateMachine) => 
            _state.Enter(stateMachine);

        public virtual void Dispose() => 
            _state.Dispose();
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
}