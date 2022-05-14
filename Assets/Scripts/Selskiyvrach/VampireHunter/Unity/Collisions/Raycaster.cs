using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Collisions
{
    public class Raycaster : MonoBehaviour
    {
        public bool Raycast(Ray ray)
        {
            return Physics.Raycast(ray);
        }

        public RaycastResult<T> Raycast<T>(Ray ray, float maxDistance) where T : MonoBehaviour
        {
            if(!Physics.Raycast(ray, out RaycastHit hit, maxDistance))
                return new RaycastResult<T>(false, null, Vector3.zero);
            return new RaycastResult<T>(true, hit.collider.GetComponent<T>(), hit.point);
        }
    }

    public readonly struct RaycastResult<T> where T : MonoBehaviour
    {
        public readonly bool HasHit;
        public readonly T Target;
        public readonly Vector3 Point;

        public RaycastResult(bool hasHit, T target, Vector3 point)
        {
            HasHit = hasHit;
            Target = target;
            Point = point;
        }
    }
}