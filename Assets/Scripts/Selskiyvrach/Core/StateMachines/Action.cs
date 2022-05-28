using System;
using System.Collections.Generic;

namespace Selskiyvrach.Core.StateMachines
{
    public interface IAction : IDisposable
    {
        void Act();
    }

    public abstract class Action : IAction
    {
        public virtual void Act()
        {
        }

        public virtual void Dispose()
        {
        }
    }

    public sealed class CompositeAction : IAction
    {
        private readonly List<IAction> _actions;

        public CompositeAction(IEnumerable<IAction> actions) =>
            _actions = new List<IAction>(actions);

        public void Act() =>
            _actions.ForEach(n => n.Act());

        public void Dispose()
        {
            
        }
    }
}