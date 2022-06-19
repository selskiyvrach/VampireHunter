using System.Linq;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.VampireHunter.Model.Arsenals;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using Selskiyvrach.VampireHunter.Model.Spreads;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Players
{
    public class Player : ITickable
    {
        private readonly ITouchInput _touchInput;
        private readonly Gunslinger _gunslinger;
        private readonly Arsenal _arsenal;
        private readonly ITicker _ticker;

        public Spread GunSpread => _gunslinger.GunSpread;

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
            else 
                _gunslinger.Shoot();
            
            _gunslinger.AdjustAimDirection(_touchInput.Delta());
            Debug.Log(_gunslinger.GunSpread.AngleDegrees);
        }
    }
}