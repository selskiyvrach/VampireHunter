using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Spreads
{
    public class SpreadKicker : SpreadTerm
    {
        private readonly IRecoilSettings _settings;

        private float _timePassedNormalized;
        private float _targetValue;
        private float _duration;
        
        public bool Finished => _timePassedNormalized >= 1;

        public SpreadKicker(IRecoilSettings settings) => 
            _settings = settings;

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