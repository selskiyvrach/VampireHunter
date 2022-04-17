using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter
{
    public class ZoomOutAction : IAction
    {
        private readonly ICameraZoomer _cameraZoomer;

        public ZoomOutAction(ICameraZoomer cameraZoomer)
        {
            _cameraZoomer = cameraZoomer;
        }

        public void Act()
        {
            _cameraZoomer.ZoomOut();
        }
    }
}