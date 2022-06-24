using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.Core.Unity.Transforms
{
    public class FollowTransformRotation : MonoBehaviour
    {
        [SerializeField] 
        private Transform _target;

        [Button]
        private void LateUpdate() => 
            transform.rotation = _target.rotation;
    }
}