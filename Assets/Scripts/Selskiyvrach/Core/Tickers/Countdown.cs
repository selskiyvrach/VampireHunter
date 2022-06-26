using System;

namespace Selskiyvrach.Core.Tickers
{
    public class Countdown : ITickable
    {
        private float _duration;
        private Action _callback;
        private float _timeSinceStarted;
        private bool _finished;

        public Countdown(float duration, Action callback)
        {
            _duration = duration;
            _callback = callback;
        }

        public void Tick(float deltaTime)
        {
            if (_finished)
                return;
            
            _timeSinceStarted += deltaTime;
            if (_timeSinceStarted < _duration)
                return;
            
            _finished = true;
            _callback.Invoke();
        }

        public void Restart()
        {
            _timeSinceStarted = 0;
            _finished = false;
        }

        public Countdown WithCallback(Action callback)
        {
            _callback = callback;
            return this;
        }

        public Countdown WithDuration(float duration)
        {
            _duration = duration;
            _timeSinceStarted = 0;
            return this;
        }
    }
}