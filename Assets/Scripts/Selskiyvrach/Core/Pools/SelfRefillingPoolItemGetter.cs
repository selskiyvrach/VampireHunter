using System;
using System.Collections.Generic;
using System.Linq;

namespace Selskiyvrach.Core.Pools
{
    public class SelfRefillingPoolItemGetter<T> : IPoolItemGetter<T>
    {
        private readonly Stack<T> _pool;
        private readonly Func<T> _factoryMethod;

        public SelfRefillingPoolItemGetter(Stack<T> pool, Func<T> factoryMethod, int initialQuantity = 0)
        {
            _pool = pool;
            _factoryMethod = factoryMethod;
            for (var i = 0; i < initialQuantity; i++)
                _pool.Push(factoryMethod.Invoke());
        }
        
        public T Get() =>
            _pool.Any() 
                ? _pool.Pop() 
                : _factoryMethod.Invoke();
    }
}