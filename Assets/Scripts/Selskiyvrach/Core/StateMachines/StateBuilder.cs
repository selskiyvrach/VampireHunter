using System.Collections.Generic;

namespace Selskiyvrach.Core.StateMachines
{
    public class StateBuilder
    {
        private readonly List<IAction> _actions = new List<IAction>();
        
        public StateBuilder OnEnter(IAction action)
        {
            _actions.Add(action);
            return this;
        }
        
        public IState Build()
        {
            State latestState = null;
            for (var i = 0; i < _actions.Count; i++)
            {
                var newState = new ActionState(_actions[i]) { Decorated = latestState};
                latestState = newState;
            }
            return latestState;
        }
        
        public static IState AddTransition(IState source, IState to, ICondition condition)
        {
            var transition = new Transition(to, condition);
            var transitionState = new TransitionState(transition) { Decorated = source };
            return transitionState;
        }

        public StateBuilder Reset()
        {
            _actions.Clear();
            return this;
        }
    }

    public static class StateExtensions
    {
        public static IState AddTransition(this IState state,  IState to, ICondition condition) => 
            StateBuilder.AddTransition(state, to, condition); 
    }
}