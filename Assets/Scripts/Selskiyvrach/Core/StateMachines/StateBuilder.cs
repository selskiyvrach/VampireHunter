using System.Collections.Generic;

namespace Selskiyvrach.Core.StateMachines
{
    public class StateBuilder
    {
        private readonly List<IAction> _onEnterActions = new List<IAction>();
        private readonly List<IAction> _onTickActions = new List<IAction>();
        private readonly List<IAction> _onExitActions = new List<IAction>();

        public StateBuilder OnEnter(IAction action)
        {
            _onEnterActions.Add(action);
            return this;
        }

        public StateBuilder OnTick(IAction action)
        {
            _onTickActions.Add(action);
            return this;
        }
        
        public StateBuilder OnExit(IAction action)
        {
            _onExitActions.Add(action);
            return this;
        }

        public IState Build()
        {
            return new State(
                PassAsItIsOrCreateComposite(_onEnterActions), 
                PassAsItIsOrCreateComposite(_onTickActions), 
                PassAsItIsOrCreateComposite(_onExitActions));
        }

        public StateBuilder Reset()
        {
            _onEnterActions.Clear();
            _onTickActions.Clear();
            _onExitActions.Clear();
            return this;
        }

        private IAction PassAsItIsOrCreateComposite(List<IAction> actions)
        {
            return actions.Count == 0 
                ? null
                : actions.Count == 1
                    ? actions[0]
                    : new CompositeAction(_onEnterActions);
        }
    }
}