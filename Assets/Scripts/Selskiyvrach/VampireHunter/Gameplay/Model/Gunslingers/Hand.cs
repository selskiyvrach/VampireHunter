using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;
using Selskiyvrach.VampireHunter.Gameplay.Model.Spreads;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers
{
    public class Hand : ITickable
    {
        private readonly RecoilProcessorComposite _recoilProcessor;

        public Hand(IRecoilProcessingSettings recoilProcessingSettings) => 
            _recoilProcessor = new RecoilProcessorComposite(recoilProcessingSettings);

        public void Tick(float deltaTime)
        {
                   
        }

        public void Kick(float recoilAmount)
        {
            
        }
    }
}