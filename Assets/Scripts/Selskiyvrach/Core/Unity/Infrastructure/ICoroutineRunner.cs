using System.Collections;
using UnityEngine;

namespace Selskiyvrach.Core.Unity.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine Run(IEnumerator enumerator);
        void Stop(Coroutine coroutine);
    }
}