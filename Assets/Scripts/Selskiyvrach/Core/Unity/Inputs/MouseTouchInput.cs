using UnityEngine;

namespace Selskiyvrach.Core.Unity.Inputs
{
    public class MouseTouchInput : TouchInput
    {
        private Vector2 _lastAimPosition;
        private Vector2 _delta;

        private void Start() => 
            _lastAimPosition = Input.mousePosition;

        private void Update()
        {
            if (!Held())
                return;

            if (Started())
                _lastAimPosition = Input.mousePosition;
            
            if(Finished())
                _delta = Vector2.zero;
            
            _delta = (Vector2)Input.mousePosition - _lastAimPosition;
            _lastAimPosition = Input.mousePosition;
        }

        public override bool Held() => 
            Input.GetMouseButton(0);

        public override bool Started() => 
            Input.GetMouseButtonDown(0);

        public override bool Finished() => 
            Input.GetMouseButtonUp(0);

        public override Vector2 Delta() =>
            _delta;
    }
}