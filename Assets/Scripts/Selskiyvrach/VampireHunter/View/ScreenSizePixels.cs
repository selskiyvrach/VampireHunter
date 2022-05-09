using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public class ScreenSizePixels : MonoBehaviour
    {   
        [SerializeField] private Camera _camera;
        
        public Vector2 ScreenSize => new Vector2(_camera.pixelWidth, _camera.pixelHeight);
    }
}