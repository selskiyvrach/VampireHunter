using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.StateMachines
{
    public class IsAimInputDownCondition : ICondition
    {
        private IGunInput _gunInput;

        public IsAimInputDownCondition(IGunInput gunInput)
        {
            _gunInput = gunInput;
        }

        public bool IsMet(StateMachine stateMachine)
        {
            return _gunInput.AimIsHeld();
        }
    }
}