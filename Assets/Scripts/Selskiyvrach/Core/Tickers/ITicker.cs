namespace Selskiyvrach.Core.Tickers
{
    public interface ITicker
    {
        void AddTickable(ITickable tickable);
        void RemoveTickable(ITickable tickable);
    }
}