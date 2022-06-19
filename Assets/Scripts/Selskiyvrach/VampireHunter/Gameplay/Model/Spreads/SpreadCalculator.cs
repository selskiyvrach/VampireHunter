using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Spreads
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
            UpdateSpread();
        }

        private void UpdateSpread() => 
            Spread = new Spread(_gunSpread.Value + _spreadKickers.Sum(n => n.Value));

        public void StartAiming()
        {
            if (_spreadKickers.Any(n => !n.Finished))
                return;
            _gunSpread.Aiming = true;
        }

        public void StopAiming() => 
            _gunSpread.Aiming = false;

        public void Kick(float value)
        {
            StopAiming();
            GetKicker().Start(value);
        }

        private SpreadKicker GetKicker()
        {
            return tryGetFinished() ?? addNew();

            SpreadKicker tryGetFinished() => 
                _spreadKickers.FirstOrDefault(k => k.Finished);

            SpreadKicker addNew()
            {
                _spreadKickers.Add(new SpreadKicker(_gun.Settings.RecoilSettings));
                return _spreadKickers.Last();
            }
        }
    }
}