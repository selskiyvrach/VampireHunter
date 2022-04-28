using UnityEngine;

namespace Selskiyvrach.Core.Unity
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