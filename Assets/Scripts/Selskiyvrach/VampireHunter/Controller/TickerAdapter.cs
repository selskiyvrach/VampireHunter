using Selskiyvrach.Core;
using Selskiyvrach.Core.Unity;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class TickerAdapter : Ticker
    {
        private readonly UpdateCallbackDispatcher _callbackDispatcher;

        public TickerAdapter(UpdateCallbackDispatcher callbackDispatcher)
        {
            _callbackDispatcher = callbackDispatcher;
            _callbackDispatcher.OnUpdate += OnTick;
        }

        private void OnTick(float deltaTime) => 
            Tick(deltaTime);
    }
}