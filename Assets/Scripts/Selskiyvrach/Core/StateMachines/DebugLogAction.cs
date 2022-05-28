using UnityEngine;

namespace Selskiyvrach.Core.StateMachines
{
    public class DebugLogAction : Action
    {
        private string _message;

        public DebugLogAction(string message) =>
            _message = message;

        public override void Act()
        {
            base.Act();
            Debug.Log(_message);
        }
    }
}