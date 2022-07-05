using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Selskiyvrach.Core.Pools
{
    public class Pool<T> : IPool<T> where T : class
    {
        private readonly Stack<T> _items = new Stack<T>();
        private IPoolItemGetter<T> _itemGetter;
        
        private Pool(){}

        public int Count() =>
            _items.Count;

        public bool Any() => 
            _items.Peek() != null;

        public T Take() =>
            _itemGetter.Get();

        public void Put(T item) => 
            _items.Push(item);
        
        public class Builder<TItem> where TItem : class
        {
            private IEnumerable<TItem> _initialItems;
            private Func<TItem> _factoryMethod;
            private int _startQuantity;

            public Builder<TItem> SelfRefillable(Func<TItem> factoryMethod, int startQuantity = 0)
            {
                _startQuantity = startQuantity;
                _factoryMethod = factoryMethod;
                return this;
            }

            public Builder<TItem> WithItems(IEnumerable<TItem> items)
            {
                _initialItems = items;
                return this;
            }

            public IPool<TItem> Build()
            {
                var pool = new Pool<TItem>();
                var itemGetter = createPoolItemGetter();
                optionallyAddPoolableHandling(ref itemGetter);
                addInitialItems();
                assignItemGetterToPool();
                return pool;

                IPoolItemGetter<TItem> createPoolItemGetter() =>
                    _factoryMethod != null
                        ? (IPoolItemGetter<TItem>) new SelfRefillingPoolItemGetter<TItem>(pool._items, _factoryMethod, _startQuantity)
                        : (IPoolItemGetter<TItem>) new SimplePoolItemGetter<TItem>(pool._items);

                void optionallyAddPoolableHandling(ref IPoolItemGetter<TItem> getter)
                {
                    if (typeof(T).GetTypeInfo().ImplementedInterfaces.Any(n => n == typeof(IPoolable<TItem>)))
                        getter = new PoolableItemsGetter<TItem>(pool, itemGetter);
                }

                void addInitialItems()
                {
                    foreach (var item in _initialItems)
                        pool.Put(item);
                }
                
                void assignItemGetterToPool() => 
                    pool._itemGetter = itemGetter;
            }
        }
    }
}