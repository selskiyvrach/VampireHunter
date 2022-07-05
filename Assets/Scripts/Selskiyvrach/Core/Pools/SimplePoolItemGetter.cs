using System.Collections.Generic;

namespace Selskiyvrach.Core.Pools
{
    public class SimplePoolItemGetter<T> : IPoolItemGetter<T>
    {
        private readonly Stack<T> _pool;

        public SimplePoolItemGetter(Stack<T> pool) => 
            _pool = pool;

        public T Get() => 
            _pool.Pop();
    }
}