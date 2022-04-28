namespace Selskiyvrach.Core.StateMachines
{
    public interface ICondition
    {
        bool IsMet(StateMachine stateMachine);
    }
}