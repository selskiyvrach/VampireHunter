using Selskiyvrach.VampireHunter.Model.Guns;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    public class GunSpread : SpreadTerm
    {
        private IAimingSettings _settings;
        private float _normalizedPos;

        public GunSpread(IAimingSettings settings) => 
            _settings = settings;

        public void ChangeSettings(IAimingSettings settings) => 
            _settings = settings;

        public bool Aiming { get; set; }
        public bool FullyAimed => _normalizedPos >= 1;
        public bool FullyHip => _normalizedPos <= 0;

        public void Tick(float deltaTime)
        {
            if (Aiming && !FullyAimed) 
                _normalizedPos += deltaTime / _settings.FromHipToAimedTime;

            if (!Aiming && !FullyHip) 
                _normalizedPos -= deltaTime / _settings.FromAimedToHipTime;

            Value = Mathf.Lerp(_settings.Accuracy, _settings.HipAccuracy, _normalizedPos);
        }
    }
}