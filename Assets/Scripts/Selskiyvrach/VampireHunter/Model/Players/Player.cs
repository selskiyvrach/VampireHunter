using System.Linq;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.VampireHunter.Model.Arsenals;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Players
{
    public class Player : ITickable
    {
        private readonly ITouchInput _touchInput;
        private readonly Gunslinger _gunslinger;
        private readonly Arsenal _arsenal;

        public Player(ITouchInput touchInput, Gunslinger gunslinger, ArsenalFactory arsenalFactory)
        {
            _touchInput = touchInput;
            _gunslinger = gunslinger;
            _arsenal = arsenalFactory.Create();
            _gunslinger.SetGun(_arsenal.Guns.First());
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