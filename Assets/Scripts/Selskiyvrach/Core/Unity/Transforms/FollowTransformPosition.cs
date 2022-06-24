using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.Core.Unity.Transforms
{
    public class FollowTransformPosition : MonoBehaviour
    {
        [SerializeField] 
        private Transform _target;

        [Button]
        private void LateUpdate() => 
            transform.position = _target.position;
    }
}