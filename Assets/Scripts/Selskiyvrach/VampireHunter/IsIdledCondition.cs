using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter
{
    public class IsIdledCondition : ICondition
    {
        private readonly ICrosshair _crosshair;

        public IsIdledCondition(ICrosshair crosshair)
        {
            _crosshair = crosshair;
        }

        public bool IsMet(StateMachine stateMachine)
        {
            return _crosshair.Idled;
        }
    }
}