using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity
{
    public class MouseGunInput : MonoBehaviour
    {
        private Vector2 _lastAimPosition;
        private Vector2 _delta;

        private void Start()
        {
            _lastAimPosition = Input.mousePosition;
        }

        private void Update()
        {
            if (!AimIsHeld())
                return;

            if (AimStarted())
                _lastAimPosition = Input.mousePosition;
            
            if(AimFinished())
                _delta = Vector2.zero;
            
            _delta = (Vector2)Input.mousePosition - _lastAimPosition;
            _lastAimPosition = Input.mousePosition;
        }

        public bool AimIsHeld()
        {
            return Input.GetMouseButton(0);
        }

        public bool AimStarted()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool AimFinished()
        {
            return Input.GetMouseButtonUp(0);
        }

        public Vector2 AimDelta() =>
            _delta;
    }
}