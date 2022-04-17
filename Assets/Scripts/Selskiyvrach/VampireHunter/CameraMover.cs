using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class CameraMover : ICameraZoomer
    {
        private readonly Camera _camera;
        private readonly Vector2 _clampX;
        private readonly Vector2 _clampY;
        private readonly Vector2 _speedRatio;
        
        private TweenerCore<float, float, FloatOptions> _tween;

        public CameraMover(Camera camera, Vector2 clampX, Vector2 clampY, Vector2 speedRatio)
        {
            _camera = camera;
            _clampX = clampX;
            _clampY = clampY;
            _speedRatio = speedRatio;
        }

        public void ZoomIn()
        {
            _tween?.Kill();
            _tween = _camera.DOFieldOfView(45, .25f);
        }

        public void ZoomOut()
        {
            _tween?.Kill();
            _tween = _camera.DOFieldOfView(60, .25f);
        }

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