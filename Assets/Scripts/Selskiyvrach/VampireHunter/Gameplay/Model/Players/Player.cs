using System.Linq;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Spreads;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Players
{
    public class Player : ITickable
    {
        private readonly ITouchInput _touchInput;
        private readonly Gunslinger _gunslinger;
        private readonly Arsenal _arsenal;
        private readonly ITicker _ticker;

        public Spread GunSpread => _gunslinger.GunSpread;
        public Gun Gun => _gunslinger.Gun;

        public Player(ITouchInput touchInput, Gunslinger gunslinger, Arsenal arsenal, ITicker ticker)
        {
            _touchInput = touchInput;
            _gunslinger = gunslinger;
            _arsenal = arsenal;
            _ticker = ticker;
            _gunslinger.SetGun(_arsenal.Guns.First());
            _ticker.AddTickable(_gunslinger);
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            if (!_touchInput.Held())
                _gunslinger.StopAiming();
            else if(!_gunslinger.FullyAimed)
                _gunslinger.StartAiming();
            else if (_gunslinger.Gun.MagazineStatus.Any)
                _gunslinger.Shoot();

            _gunslinger.AdjustAimDirection(_touchInput.Delta());
        }
    }
}