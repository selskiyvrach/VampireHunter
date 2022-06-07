using UnityEngine;

namespace Selskiyvrach.Core.Unity.Cameras
{
    public class ScreenSizePixels : MonoBehaviour, IScreenSizePixels
    {   
        [SerializeField] private Camera _camera;
        
        public Vector2 ScreenSize => new Vector2(_camera.pixelWidth, _camera.pixelHeight);
    }
}