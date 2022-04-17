namespace Selskiyvrach.Core.StateMachines
{
    public sealed class State : IState
    {
        private readonly IAction _onEnterAction;
        private readonly IAction _onTickAction;
        private readonly IAction _onExitAction;
        private readonly CompositeTransition _transition = new CompositeTransition();

        public State(
            IAction onEnterAction = null,
            IAction onTickAction = null,
            IAction onExitAction = null)
        {
            _onEnterAction = onEnterAction;
            _onTickAction = onTickAction;
            _onExitAction = onExitAction;
        }

        public void AddTransition(IState to, ICondition condition) =>
            _transition.AddTransition(new Transition(to, condition));

        public void Enter(StateMachine stateMachine)
        {
            if (_transition?.TryTransition(stateMachine) ?? false)
                return;
            _onEnterAction?.Act();
        }

        public void Tick(StateMachine stateMachine)
        {
            if (_transition?.TryTransition(stateMachine) ?? false)
                return;
            _onTickAction?.Act();
        }

        public void Exit() =>
            _onExitAction?.Act();
    }
}