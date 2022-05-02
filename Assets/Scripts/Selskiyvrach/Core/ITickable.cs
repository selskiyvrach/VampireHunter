namespace Selskiyvrach.Core
{
    public interface ITickable
    {
        void Tick(float deltaTime);
    }
    
    public interface ILateTickable
    {
        void OnAfterTick(float deltaTime);
    }
}