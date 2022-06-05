using Selskiyvrach.Core.Tickers;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Spread
{
    public class SpreadKicker : SpreadTerm, ITickable
    {
        private readonly SpreadKickerSettings _settings;
        private readonly ITicker _ticker;

        private float _timePassedNormalized;
        private float _targetValue;
        private float _duration;
        
        public bool Finished => _timePassedNormalized >= 1;

        public SpreadKicker(SpreadKickerSettings settings, ITicker ticker)
        {
            _settings = settings;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Start(float targetValue)
        {
            _duration = targetValue / _settings.RecoilUnitsProcessedPerSecond;
            _targetValue = targetValue;
            _timePassedNormalized = 0;
        }

        public void Tick(float deltaTime)
        {
            if(Finished)
                return;
            
            _timePassedNormalized += deltaTime / _duration;
            Value = _targetValue * _settings.AnimationCurve.Evaluate(_timePassedNormalized);
        }
    }
}