using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Cameras
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Vector2 _clampX;
        [SerializeField] private Vector2 _clampY;
        [SerializeField] private Vector2 _speedRatio;
        
        public void Move(Vector2 delta)
        {
            var angles = _camera.transform.eulerAngles;
            var rotationX = angles.x;
            var rotationY = angles.y;

            if (delta.y != 0)
                if(rotationX < _clampY.y || rotationX > 360 + _clampY.x)
                    rotationX -= delta.y * _speedRatio.x;

            if (rotationX > _clampY.y && rotationX < 360 + _clampY.x)
                rotationX = delta.y < 0 
                    ? _clampY.y - 0.1f
                    : 360 + _clampY.x + 0.1f;
                
            if (delta.x != 0)
                if(rotationY < _clampX.y || rotationY > 360 + _clampX.x)
                    rotationY += delta.x * _speedRatio.y;

            if (rotationY > _clampX.y && rotationY < 360 + _clampX.x)
                rotationY = delta.x > 0 
                    ? _clampX.y - 0.1f
                    : 360 + _clampX.x + 0.1f;


            _camera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }
}