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

        public void Enter() =>
            _onEnterAction?.Act();

        public void Tick(StateMachine stateMachine)
        {
            _onTickAction?.Act();
            _transition?.TryTransition(stateMachine);
        }

        public void Exit() =>
            _onExitAction?.Act();
    }
}