using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    public class SpreadCalculator
    {
        private readonly GunSpread _gunSpread;
        private readonly List<SpreadKicker> _spreadKickers = new List<SpreadKicker>();
        private Gun _gun;

        public Spread Spread { get; private set; }
        public bool FullyAimed => _gunSpread.FullyAimed;
        public bool FullyHip => _gunSpread.FullyHip;
        
        public SpreadCalculator(Gun gun)
        {
            _gun = gun;
            _gunSpread = new GunSpread(_gun.Settings.AimingSettings);
        }

        public void ChangeGun(Gun gun)
        {
            _gun = gun;
            _spreadKickers.Clear();
            _gunSpread.ChangeSettings(_gun.Settings.AimingSettings);
        }

        public void Tick(float deltaTime)
        {
            _gunSpread.Tick(deltaTime);
            _spreadKickers.ForEach(n => n.Tick(deltaTime));
            Spread = new Spread(_gunSpread.Value + _spreadKickers.Sum(n => n.Value));
        }

        public void StartAiming() => 
            _gunSpread.Aiming = true;

        public void StopAiming() => 
            _gunSpread.Aiming = false;

        public void Kick(float value)
        {
            var spreadKicker = GetKicker();
            spreadKicker.Start(value);
        }

        private SpreadKicker GetKicker()
        {
            SpreadKicker spreadKicker = null;
            for (var i = 0; i < _spreadKickers.Count; i++)
                if (_spreadKickers[i].Finished)
                    spreadKicker = _spreadKickers[i];
            if (spreadKicker == null)
            {
                spreadKicker = new SpreadKicker(_gun.Settings.RecoilSettings);
                _spreadKickers.Add(spreadKicker);
            }
            return spreadKicker;
        }
    }
}