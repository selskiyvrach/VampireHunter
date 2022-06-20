using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Spreads
{
    public class GunSpread : ITickable
    {
        private IAimingSettings _settings;
        private float _normalizedPos;

        public float Value { get; private set; }
        public bool Aiming { get; set; }
        public bool FullyAimed => _normalizedPos >= 1;
        public bool FullyHip => _normalizedPos <= 0;

        public GunSpread(IAimingSettings settings) => 
            _settings = settings;

        public void ChangeSettings(IAimingSettings settings) => 
            _settings = settings;

        public void Tick(float deltaTime)
        {
            if (Aiming && !FullyAimed)
                _normalizedPos += deltaTime / _settings.FromHipToAimedTime;
            if (!Aiming && !FullyHip)
                _normalizedPos -= deltaTime / _settings.FromAimedToHipTime;

            Value = Mathf.Lerp(_settings.HipAccuracy, _settings.Accuracy, _normalizedPos);
        }
    }
}