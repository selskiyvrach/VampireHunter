namespace Selskiyvrach.Core.Pools
{
    public interface IPoolable<T> where T : class
    {
        void AssignToPool(IPool<T> pool);
        void Release();
    }
}