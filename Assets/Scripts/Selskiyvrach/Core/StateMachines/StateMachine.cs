namespace Selskiyvrach.Core.StateMachines
{
    public sealed class StateMachine 
    {
        private IState _currentState;

        public void StartState(IState state)
        {
            _currentState?.Dispose();
            _currentState = state;
            _currentState.Enter(this);
        }
    }
}