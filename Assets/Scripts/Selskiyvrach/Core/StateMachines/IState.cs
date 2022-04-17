namespace Selskiyvrach.Core.StateMachines
{
    public interface IState
    {
        void AddTransition(IState to, ICondition condition);
        void Enter(StateMachine stateMachine);
        void Tick(StateMachine stateMachine);
        void Exit();
    }
}