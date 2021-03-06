using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Spreads
{
    public class RecoilProcessor : ITickable
    {
        private readonly IRecoilProcessingSettings _recoilProcessingSettings;

        private float _timePassedNormalized;
        private float _targetValue;
        private float _duration;

        public float Value { get; private set; }
        public bool Finished => _timePassedNormalized >= 1;


        public RecoilProcessor(IRecoilProcessingSettings recoilProcessingSettings) => 
            _recoilProcessingSettings = recoilProcessingSettings;

        public void Start(float value)
        {
            _duration = value / _recoilProcessingSettings.RecoilUnitsProcessedPerSecond;
            _targetValue = value;
            _timePassedNormalized = 0;
        }

        public void Tick(float deltaTime)
        {
            if(Finished)
                return;
            
            _timePassedNormalized += deltaTime / _duration;
            Value = _targetValue * _recoilProcessingSettings.AnimationCurve.Evaluate(_timePassedNormalized);
        }
    }
}