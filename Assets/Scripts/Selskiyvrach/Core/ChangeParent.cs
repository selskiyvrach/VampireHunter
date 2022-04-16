using UnityEngine;

namespace Selskiyvrach.Core
{
    public class ChangeParent : MonoBehaviour
    {
        [SerializeField] 
        private Transform _runtimeParent;
        
        private void Start()
        {
            transform.SetParent(_runtimeParent);
        }
    }
}