using System.Collections.Generic;

namespace Selskiyvrach.Core
{
    public class Ticker : ITicker, ITickable
    {
        private readonly List<ITickable> _tickables = new List<ITickable>();
        
        public bool AddTickable(ITickable tickable)
        {
            if (_tickables.Contains(tickable))
                return false;
            _tickables.Add(tickable);
            return true;
        }

        public bool RemoveTickable(ITickable tickable) => 
            _tickables.Remove(tickable);

        public void Tick(float deltaTime)
        {
            for (var i = 0; i < _tickables.Count; i++)
            {
                _tickables[i].Tick(deltaTime);
            }

            foreach (var tickable in _tickables)
            {
            }
        }
    }
}