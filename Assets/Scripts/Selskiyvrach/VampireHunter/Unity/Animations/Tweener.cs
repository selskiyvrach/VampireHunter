using System;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public abstract class Tweener : MonoBehaviour, ICallback
    {
        public event Action OnInvoked;

        public abstract void Play();

        public abstract void Kill();

        protected void Complete() =>
            OnInvoked?.Invoke();

    }
}