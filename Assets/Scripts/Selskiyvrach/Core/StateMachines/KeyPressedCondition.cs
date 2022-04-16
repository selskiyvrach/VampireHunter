using UnityEngine;

namespace Selskiyvrach.Core.StateMachines
{
    public class KeyPressedCondition : ICondition
    {
        private readonly KeyCode _keyCode;

        public KeyPressedCondition(KeyCode keyCode) =>
            _keyCode = keyCode;

        public bool IsMet(StateMachine stateMachine) =>
            Input.GetKeyDown(_keyCode);
    }
}