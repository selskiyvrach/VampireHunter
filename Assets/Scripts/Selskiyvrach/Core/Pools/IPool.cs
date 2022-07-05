namespace Selskiyvrach.Core.Pools
{
    public interface IPool
    {
        int Count();
        bool Any();
    }

    public interface IPool<T> : IPool where T : class
    {
        T Take();
        void Put(T item);
    }
}