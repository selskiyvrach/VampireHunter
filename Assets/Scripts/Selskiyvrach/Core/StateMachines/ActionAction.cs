using System;

namespace Selskiyvrach.Core.StateMachines
{
    public class ActionAction : IAction
    {
        private readonly Action _action;

        public ActionAction(Action action) => 
            _action = action;

        public void Act() => 
            _action.Invoke();
    }
}