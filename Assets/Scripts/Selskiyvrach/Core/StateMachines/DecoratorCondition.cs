namespace Selskiyvrach.Core.StateMachines
{
    public abstract class DecoratorCondition : ICondition
    {
        protected readonly ICondition Condition;

        protected DecoratorCondition(ICondition condition)
        {
            Condition = condition;
        }

        public abstract bool IsMet(StateMachine stateMachine);
    }
}