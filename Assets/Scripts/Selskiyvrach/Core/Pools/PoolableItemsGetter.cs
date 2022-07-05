namespace Selskiyvrach.Core.Pools
{
    public class PoolableItemsGetter<T> : IPoolItemGetter<T> where T : class
    {
        private readonly IPool<T> _pool;
        private readonly IPoolItemGetter<T> _decoratedGetter;

        public PoolableItemsGetter(IPool<T> pool, IPoolItemGetter<T> decoratedGetter)
        {
            _pool = pool;
            _decoratedGetter = decoratedGetter;
        }

        public T Get()
        {
            var item = _decoratedGetter.Get();
            (item as IPoolable<T>)?.AssignToPool(_pool);
            return item;
        }
    }
}