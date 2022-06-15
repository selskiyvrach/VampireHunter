using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Players
{
    public class Player : ITickable
    {
        private readonly ArsenalOperator _arsenalOperator = new ArsenalOperator();
        private readonly Gunslinger _gunslinger;
        private readonly ITouchInput _touchInput;
        private readonly ITicker _ticker;

        public Player(ITouchInput touchInput, Gunslinger gunslinger, ITicker ticker)
        {
            _touchInput = touchInput;
            _gunslinger = gunslinger;
            _ticker = ticker;
            _ticker.AddTickable(this);
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