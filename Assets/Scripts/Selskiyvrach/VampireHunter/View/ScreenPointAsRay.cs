using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public class ScreenPointAsRay : MonoBehaviour
    {
        [SerializeField] private RectTransform _crosshair;
        [SerializeField] private Camera _camera;

        public Ray GetRay() =>
            _camera.ScreenPointToRay(_crosshair.position);
    }
}