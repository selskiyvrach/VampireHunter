using UnityEngine;

namespace Selskiyvrach.Core.Unity.Cameras
{
    public class CamFieldOfView : MonoBehaviour, ICamFieldOfView
    {
        [SerializeField] private Camera _camera;

        public float FieldOfView => _camera.fieldOfView;
    }
}