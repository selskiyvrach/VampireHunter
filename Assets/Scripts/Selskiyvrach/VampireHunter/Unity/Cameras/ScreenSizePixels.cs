using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Cameras
{
    public class ScreenSizePixels : MonoBehaviour
    {   
        [SerializeField] private Camera _camera;
        
        public Vector2 ScreenSize => new Vector2(_camera.pixelWidth, _camera.pixelHeight);
    }
}