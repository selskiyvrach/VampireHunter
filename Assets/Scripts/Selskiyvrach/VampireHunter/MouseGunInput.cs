using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class MouseGunInput : MonoBehaviour, IGunInput
    {
        private Vector2 _lastAimPosition;
        
        public bool AimIsHeld()
        {
            return Input.GetMouseButton(0);
        }

        public bool AimStarted()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool AimIsFinished()
        {
            return Input.GetMouseButtonUp(0);
        }

        public Vector2 AimDelta()
        {
            var delta = (Vector2)Input.mousePosition - _lastAimPosition;
            _lastAimPosition = Input.mousePosition;
            return delta;
        }
    }
}