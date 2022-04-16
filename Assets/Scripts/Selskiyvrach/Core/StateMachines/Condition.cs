namespace Selskiyvrach.Core.StateMachines
{
    public interface ICondition
    {
        bool IsMet(StateMachine stateMachine);
    }

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