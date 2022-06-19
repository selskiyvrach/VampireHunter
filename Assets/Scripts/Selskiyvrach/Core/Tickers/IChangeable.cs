namespace Selskiyvrach.Core.Tickers
{
    public interface IChangeable
    {
        bool ChangedLastTick { get; }
        void OnAfterTick();
    }
}