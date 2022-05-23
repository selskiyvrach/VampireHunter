using System.Collections.Generic;

namespace Selskiyvrach.Core
{
    public interface ITickable
    {
        void Tick(float deltaTime);
    }
    
    public class Ticker : ITickable, ITicker
    {
        private readonly List<ITickable> _tickables = new List<ITickable>();
        
        public void Tick(float deltaTime) => 
            _tickables.ForEach(n => n.Tick(deltaTime));

        public void AddTickable(ITickable tickable) => 
            _tickables.Add(tickable);

        public void RemoveTickable(ITickable tickable) => 
            _tickables.Remove(tickable);
    }

    public interface ITicker
    {
        void AddTickable(ITickable tickable);
        void RemoveTickable(ITickable tickable);
    }
}