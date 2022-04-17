using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter
{
    public class ZoomInAction : IAction
    {
        private readonly ICameraZoomer _cameraZoomer;

        public ZoomInAction(ICameraZoomer cameraZoomer)
        {
            _cameraZoomer = cameraZoomer;
        }

        public void Act()
        {
            _cameraZoomer.ZoomIn();
        }
    }
}