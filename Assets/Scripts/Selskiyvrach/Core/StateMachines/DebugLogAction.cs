using UnityEngine;

namespace Selskiyvrach.Core.StateMachines
{
    public class DebugLogAction : IAction
    {
        private string _message;

        public DebugLogAction(string message) =>
            _message = message;

        public void Act() =>
            Debug.Log(_message);          
    }
}