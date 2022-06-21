using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Spreads
{
    public class RecoilProcessorComposite : ITickable
    {
        private readonly List<RecoilProcessor> _spreadKickers = new List<RecoilProcessor>();
        private readonly IRecoilProcessingSettings _recoilProcessingRecoilProcessingSettings;

        public float Value { get; private set; }

        public RecoilProcessorComposite(IRecoilProcessingSettings recoilProcessingRecoilProcessingSettings) => 
            _recoilProcessingRecoilProcessingSettings = recoilProcessingRecoilProcessingSettings;

        public void Tick(float deltaTime)
        {
            Value = 0;
            
            foreach (var processor in _spreadKickers)
            {
                if (processor.Finished)
                    continue;
                processor.Tick(deltaTime);
                Value += processor.Value;
            }
        }

        public void Kick(float value) => 
            GetKicker().Start(value);

        private RecoilProcessor GetKicker()
        {
            return tryGetFinished() ?? addNew();

            RecoilProcessor tryGetFinished() => 
                _spreadKickers.FirstOrDefault(k => k.Finished);

            RecoilProcessor addNew()
            {
                _spreadKickers.Add(new RecoilProcessor(_recoilProcessingRecoilProcessingSettings));
                return _spreadKickers.Last();
            }
        }
    }
}