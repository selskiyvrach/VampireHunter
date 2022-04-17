using System.Collections.Generic;

namespace Selskiyvrach.Core.StateMachines
{
    public class CompositeCondition : ICondition
    {
        private readonly List<ICondition> _conditions;

        public CompositeCondition(List<ICondition> conditions)
        {
            _conditions = conditions;
        }

        public bool IsMet(StateMachine stateMachine)
        {
            return _conditions.TrueForAll(n => n.IsMet(stateMachine));
        }
    }
}