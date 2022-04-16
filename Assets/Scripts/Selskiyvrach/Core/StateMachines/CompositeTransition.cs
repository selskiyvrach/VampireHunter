using System.Collections.Generic;

namespace Selskiyvrach.Core.StateMachines
{
    public sealed class CompositeTransition : ITransition
    {
        private readonly List<ITransition> _transitions = new List<ITransition>();

        public void AddTransition(ITransition transition) =>
            _transitions.Add(transition);

        public bool TryTransition(StateMachine stateMachine)
        {
            foreach (var transition in _transitions)
                if (transition.TryTransition(stateMachine))
                    return true;
            return false;
        }
    }
}