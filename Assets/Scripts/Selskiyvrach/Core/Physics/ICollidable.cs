namespace Selskiyvrach.Core.Physics
{
    public interface ICollidable<in T>
    {
        void OnCollided(T bullet);
    }
}