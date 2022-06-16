using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Guns;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    public class AimSpread : SpreadTerm, ITickable
    {
        private readonly ITicker _ticker;
        private float _normalizedPos;

        public IAimingSettings Settings { get; private set; }
        public bool Aiming { get; set; }
        public bool FullyAimed => _normalizedPos >= 1;
        public bool FullyHip => _normalizedPos <= 0;

        public AimSpread(ITicker ticker)
        {
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            if (Aiming && !FullyAimed) 
                _normalizedPos += deltaTime / Settings.FromHipToAimedTime;

            if (!Aiming && !FullyHip) 
                _normalizedPos -= deltaTime / Settings.FromAimedToHipTime;

            Value = Mathf.Lerp(Settings.Accuracy, Settings.HipAccuracy, _normalizedPos);
        }
    }
}