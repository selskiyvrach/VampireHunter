namespace Selskiyvrach.Core.Pools
{
    public interface IPoolItemGetter<T>
    {
        T Get();
    }
}