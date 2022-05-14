using System.Collections;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Infrastructure
{
    public class CoroutineRunner : MonoBehaviour
    {
        public Coroutine Run(IEnumerator enumerator) => 
            StartCoroutine(enumerator);

        public void Stop(Coroutine coroutine) => 
            StopCoroutine(coroutine);
    }
}