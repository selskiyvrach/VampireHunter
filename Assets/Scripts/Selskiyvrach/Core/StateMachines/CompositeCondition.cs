using System.Collections.Generic;
using System.Linq;

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

    public class CompositeConditionBuilder
    {
        private readonly HashSet<ICondition> _conditions = new HashSet<ICondition>();

        public CompositeConditionBuilder Add(ICondition condition)
        {
            _conditions.Add(condition);
            return this;
        }

        public ICondition Build()
        {
            if(_conditions.Count == 0)
                return new NegatorCondition(new TrueCondition());
            return new CompositeCondition(_conditions.ToList());
        }
    }
}