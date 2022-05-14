using System;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Collisions
{
    public class TriggerCallback<T> : MonoBehaviour where T : MonoBehaviour
    {
        public event Action<T> OnEntered; 
        
        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<T>();
            if (target == null)
                return;
            OnEntered?.Invoke(target);
        }
    }
}