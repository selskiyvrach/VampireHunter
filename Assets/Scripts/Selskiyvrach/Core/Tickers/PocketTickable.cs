using System;

namespace Selskiyvrach.Core.Tickers
{
    public class PocketTickable : ITickable
    {
        private readonly Action<float> _action;

        public PocketTickable(Action action) => 
            _action = _ => action.Invoke();

        public PocketTickable(Action<float> action) => 
            _action = action;
        
        public void Tick(float deltaTime) => 
            _action?.Invoke(deltaTime);
    }
}