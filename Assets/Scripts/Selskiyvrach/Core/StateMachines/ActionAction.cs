namespace Selskiyvrach.Core.StateMachines
{
    public class ActionAction : IAction
    {
        private readonly System.Action _action;

        public ActionAction(System.Action action) => 
            _action = action;

        public void Act() => 
            _action.Invoke();

        public void Dispose()
        {
        }
    }
}