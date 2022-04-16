namespace Selskiyvrach.Core.StateMachines
{
    public interface ITransition
    {
        bool TryTransition(StateMachine stateMachine);
    }

    public sealed class Transition : ITransition
    {
        private readonly ICondition _condition;
        private readonly IState _state;

        public Transition(IState state, ICondition condition)
        {
            _state = state;
            _condition = condition;
        }

        public bool TryTransition(StateMachine stateMachine)
        {
            if (!_condition.IsMet(stateMachine))
                return false;
            stateMachine.StartState(_state);
            return true;
        }
    }
}