namespace Selskiyvrach.Core.StateMachines
{
    public class TrueCondition : ICondition
    {
        public bool IsMet(StateMachine stateMachine) =>
            true;
    }
}