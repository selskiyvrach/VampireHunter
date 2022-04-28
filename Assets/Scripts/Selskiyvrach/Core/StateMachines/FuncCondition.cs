using System;

namespace Selskiyvrach.Core.StateMachines
{
    public class FuncCondition : ICondition
    {
        private readonly Func<bool> _func;

        public FuncCondition(Func<bool> func)
        {
            _func = func;
        }

        public bool IsMet(StateMachine stateMachine)
        {
            return _func.Invoke();
        }
    }
}