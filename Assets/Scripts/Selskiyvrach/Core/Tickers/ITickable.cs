namespace Selskiyvrach.Core.Tickers
{
    public interface ITickable
    {
        void Tick(float deltaTime);
    }
}