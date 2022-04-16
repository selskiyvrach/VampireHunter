namespace Selskiyvrach.Core.StateMachines
{
    public interface IState
    {
        void AddTransition(IState to, ICondition condition);
        void Enter();
        void Tick(StateMachine stateMachine);
        void Exit();
    }
}