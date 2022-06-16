using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.VampireHunter.Model.Arsenal;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Players
{
    public class Player : ITickable
    {
        private readonly Arsenal.Arsenal _arsenal;
        private readonly Gunslinger _gunslinger;
        private readonly ITouchInput _touchInput;
        private readonly ITicker _ticker;

        public Player(ITouchInput touchInput, Gunslinger gunslinger, ITicker ticker, ArsenalFactory arsenalFactory)
        {
            _touchInput = touchInput;
            _gunslinger = gunslinger;
            _ticker = ticker;
            _ticker.AddTickable(this);
            _arsenal = arsenalFactory.Create();
        }

        public void Tick(float deltaTime)
        {
            if (!_touchInput.Held())
                _gunslinger.StopAiming();
            else if(!_gunslinger.FullyAimed)
                _gunslinger.StartAiming();
            
            _gunslinger.AdjustAimDirection(_touchInput.Delta());
        }
    }
}