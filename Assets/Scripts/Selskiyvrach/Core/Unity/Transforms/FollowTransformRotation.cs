using UnityEngine;

namespace Selskiyvrach.Core.Unity.Transforms
{
    public class FollowTransformRotation : MonoBehaviour
    {
        [SerializeField] 
        private Transform _target;

        private void LateUpdate() => 
            transform.rotation = _target.rotation;
    }
}