using System.Collections;
using UnityEngine;

namespace Selskiyvrach.Core.Unity
{
    public class CoroutineRunner : MonoBehaviour
    {
        public Coroutine Run(IEnumerator enumerator) => 
            StartCoroutine(enumerator);

        public void Stop(Coroutine coroutine) => 
            StopCoroutine(coroutine);
    }
}