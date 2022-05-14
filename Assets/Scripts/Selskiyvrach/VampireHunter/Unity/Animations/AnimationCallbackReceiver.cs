using System;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public abstract class AnimationCallbackReceiver : MonoBehaviour, ICallback
    {
        public event Action OnInvoked;

        protected void InvokeInternal()
        {
            OnInvoked?.Invoke();
        }
    }

    namespace Selskiyvrach.VampireHunter
    {
    }
}