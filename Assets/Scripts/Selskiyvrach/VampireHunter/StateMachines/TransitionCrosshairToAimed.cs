using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.StateMachines
{
    public class TransitionCrosshairToAimed : IAction
    {
        private readonly ICrosshair _crosshair;

        public TransitionCrosshairToAimed(ICrosshair crosshair)
        {
            _crosshair = crosshair;
        }

        public void Act()
        {
            _crosshair.TransitionToAimed();
        }
    }
}