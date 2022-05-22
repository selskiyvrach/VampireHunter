using System;
using UnityEngine;

namespace Selskiyvrach.Core.Unity
{
    public class UpdateCallbackDispatcher : MonoBehaviour
    {
        public event Action<float> OnUpdate;

        private void Update() => 
            OnUpdate?.Invoke(Time.deltaTime);
    }
}