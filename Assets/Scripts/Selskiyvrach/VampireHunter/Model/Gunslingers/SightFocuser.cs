using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class SightFocuser
    {
        private readonly Camera _camera;

        public SightFocuser(Camera camera) => 
            _camera = camera;

        public void FocusIn() => 
            _camera.fieldOfView = 45;

        public void FocusOut() => 
            _camera.fieldOfView = 60;
    }
}