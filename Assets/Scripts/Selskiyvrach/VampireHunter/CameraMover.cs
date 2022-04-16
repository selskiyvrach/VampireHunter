using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class CameraMover
    {
        private Camera _camera;

        public CameraMover(Camera camera)
        {
            _camera = camera;
        }

        public void ZoomIn()
        {
            
        }

        public void ZoomOut()
        {
            
        }

        public void Move(Vector2 delta)
        {
            _camera.transform.eulerAngles += new Vector3(- delta.y * 0.1f, delta.x * 0.1f, 0);
        }
    }
}