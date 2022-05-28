namespace Selskiyvrach.Core.StateMachines
{
    public sealed class StateMachine : Ticker
    {
        public IState CurrentState { get; private set; }

        public void StartState(IState state)
        {
            CurrentState?.Dispose();
            CurrentState = state;
            CurrentState.Enter(this);
        }
    }
}