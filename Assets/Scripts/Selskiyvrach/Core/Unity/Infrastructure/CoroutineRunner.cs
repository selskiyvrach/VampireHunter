using System.Collections;
using UnityEngine;

namespace Selskiyvrach.Core.Unity.Infrastructure
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public Coroutine Run(IEnumerator enumerator) => 
            StartCoroutine(enumerator);

        public void Stop(Coroutine coroutine) => 
            StopCoroutine(coroutine);
    }
}