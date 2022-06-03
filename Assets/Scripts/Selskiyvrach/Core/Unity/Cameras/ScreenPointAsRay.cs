using UnityEngine;

namespace Selskiyvrach.Core.Unity.Cameras
{
    public class ScreenPointAsRay : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public Ray GetRay(Vector2 screenPosNormalized)
        {
            var screenPoint = screenPosNormalized * new Vector2(_camera.pixelWidth, _camera.pixelHeight);
            return _camera.ScreenPointToRay(screenPoint);
        }

        private void OnDrawGizmos()
        {
            var ray = GetRay(new Vector2(.5f, .5f));
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 100);
        }
    }
}