namespace Selskiyvrach.Core.StateMachines
{
    public class NegatorCondition : DecoratorCondition
    {
        public NegatorCondition(ICondition condition) : base(condition)
        {
        }

        public override bool IsMet(StateMachine stateMachine)
        {
            return !Condition.IsMet(stateMachine);
        }
    }
}