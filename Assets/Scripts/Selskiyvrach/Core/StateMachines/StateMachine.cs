namespace Selskiyvrach.Core.StateMachines
{
    public sealed class StateMachine : ITickable
    {
        private IState _currentState;

        public StateMachine(IState startState) =>
            StartState(startState);

        public void Tick(float deltaTime)
        {
            _currentState?.Tick(this);
        }

        public void StartState(IState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter(this);
        }
    }
}