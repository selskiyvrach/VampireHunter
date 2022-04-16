using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.StateMachines
{
    public class CrosshairCenteredCondition : ICondition
    {
        private readonly ICrosshair _crosshair;

        public CrosshairCenteredCondition(ICrosshair crosshair) =>
            _crosshair = crosshair;

        public bool IsMet(StateMachine stateMachine) =>
            _crosshair.Aimed;
    }
}