using System;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public abstract class AnimationCallbackReceiver : MonoBehaviour, ICallback
    {
        public event Action OnInvoked;

        protected void InvokeInternal()
        {
            OnInvoked?.Invoke();
        }
    }
}