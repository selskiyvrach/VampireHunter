using Selskiyvrach.Core.Tickers;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    public class AimSpread : SpreadTerm, ITickable
    {
        private readonly GunBaseSpread _baseSpread;
        private readonly AimSpreadSettings _settings;
        private readonly ITicker _ticker;

        private float _normalizedPos;
        
        public bool Aiming { get; set; }
        public bool FullyAimed => _normalizedPos >= 1;
        public bool ZeroAimed => _normalizedPos <= 0;

        public AimSpread(GunBaseSpread baseSpread, AimSpreadSettings settings, ITicker ticker)
        {
            _baseSpread = baseSpread;
            _settings = settings;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            if (Aiming && !FullyAimed) 
                _normalizedPos += deltaTime / _settings.FromNotAimedToFullyAimedDuration;

            if (!Aiming && !ZeroAimed) 
                _normalizedPos -= deltaTime / _settings.FromAimedToNotAimedDuration;

            Value = Mathf.Lerp(_baseSpread.Value, _baseSpread.Value * _settings.SpreadWhenAimedCoefficient, _normalizedPos);
        }
    }
}