namespace Selskiyvrach.Core
{
    public interface ITickable
    {
        void Tick(float deltaTime);
    }

    public interface ITicker
    {
        bool AddTickable(ITickable tickable);
        bool RemoveTickable(ITickable tickableState);
    }
}