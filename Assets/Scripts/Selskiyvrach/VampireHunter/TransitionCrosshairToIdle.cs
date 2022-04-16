using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter
{
    public class TransitionCrosshairToIdle : IAction
    {
        private readonly ICrosshair _crosshair;

        public TransitionCrosshairToIdle(ICrosshair crosshair)
        {
            _crosshair = crosshair;
        }

        public void Act()
        {
            _crosshair.TransitionToIdle();            
        }
    }
}