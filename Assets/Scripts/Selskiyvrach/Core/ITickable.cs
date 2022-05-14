using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.Core
{
    public interface ITickable
    {
        void Tick(float deltaTime);
    }

    public interface ITicker
    {
        void AddTickable(ITickable tickable);
        void RemoveTickable(ITickable tickableState);
    }
}