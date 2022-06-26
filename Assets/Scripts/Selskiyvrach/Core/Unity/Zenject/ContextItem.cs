using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Zenject
{
    public class ContextItem : MonoBehaviour
    {
        
    }

    public class ContextItem<T> : ContextItem
    {
        public T Item { get; private set; }

        [Inject]
        public void Construct(T item) => 
            Item = item;
    }
}