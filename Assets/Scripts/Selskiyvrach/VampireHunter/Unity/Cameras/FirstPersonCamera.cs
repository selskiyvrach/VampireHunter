using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Cameras
{
    public class FirstPersonCamera : MonoBehaviour
    {
        [SerializeField] private CameraMover _cameraMover;
        [SerializeField] private MouseGunInput _mouseGunInput;

        private void LateUpdate()
        {
            if(_mouseGunInput.AimIsHeld())
                _cameraMover.Move(_mouseGunInput.AimDelta());
        }
    }
}