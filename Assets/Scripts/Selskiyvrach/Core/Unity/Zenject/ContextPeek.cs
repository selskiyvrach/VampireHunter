using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Zenject
{
    public class ContextPeek : MonoBehaviour
    {
        
    }

    public class ContextPeek<T> : ContextPeek
    {
        public T Item { get; private set; }

        [Inject]
        public void Construct(T item) => 
            Item = item;
    }
}