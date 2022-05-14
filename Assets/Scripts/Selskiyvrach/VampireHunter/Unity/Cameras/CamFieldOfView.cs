using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Cameras
{
    public class CamFieldOfView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public float FieldOfView => _camera.fieldOfView;
    }
}