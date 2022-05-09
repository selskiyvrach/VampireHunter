using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public class CamFieldOfView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public float FieldOfView => _camera.fieldOfView;
    }
}