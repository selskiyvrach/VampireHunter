using Selskiyvrach.Core.Tickers;
using UnityEngine;

namespace Selskiyvrach.Core.Unity.Tickers
{
    public class TickerRunner : MonoBehaviour, ITicker
    {
        private readonly Ticker _ticker = new Ticker();

        private void Update() => 
            _ticker.Tick(Time.deltaTime);

        public void AddTickable(ITickable tickable) => 
            _ticker.AddTickable(tickable);

        public void RemoveTickable(ITickable tickable) => 
            _ticker.RemoveTickable(tickable);
    }
}