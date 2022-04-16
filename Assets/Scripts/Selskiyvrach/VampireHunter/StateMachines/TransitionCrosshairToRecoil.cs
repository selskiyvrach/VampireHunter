
using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.StateMachines
{
    public class TransitionCrosshairToRecoil : IAction
    {
        private readonly ICrosshair _crosshair;

        public TransitionCrosshairToRecoil(ICrosshair crosshair)
        {
            _crosshair = crosshair;
        }

        public void Act()
        {
            _crosshair.TransitionToRecoil();   
        }
    }
}