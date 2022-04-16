using UnityEngine;

namespace Selskiyvrach.Core
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] 
        private Transform _target;

        private void LateUpdate()
        {
            transform.position = _target.position;
        }
    }
}