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

        public void AddTickable(TickableState tickableState)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTickable(TickableState tickableState)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Ticker
    {
    }
}