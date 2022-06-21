using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Spreads
{
    public class SpreadCalculator
    {
        private readonly RecoilProcessorComposite _recoilProcessor;
        private readonly GunSpread _gunSpread;
        private Gun _gun;

        public Spread Spread { get; private set; }
        public bool FullyAimed => _gunSpread.FullyAimed;
        
        public SpreadCalculator(Gun gun, ISpreadRecoilProcessingSettings recoilProcessingRecoilProcessingSettings)
        {
            _gun = gun;
            _recoilProcessor = new RecoilProcessorComposite(recoilProcessingRecoilProcessingSettings);
            _gunSpread = new GunSpread(_gun.Settings.AimingSettings);
        }

        public void ChangeGun(Gun gun)
        {
            _gun = gun;
            _gunSpread.ChangeSettings(_gun.Settings.AimingSettings);
        }

        public void Tick(float deltaTime)
        {
            _gunSpread.Tick(deltaTime);
            _recoilProcessor.Tick(deltaTime);
            UpdateSpread();
        }

        private void UpdateSpread() => 
            Spread = new Spread(_gunSpread.Value + _recoilProcessor.Value);

        public void StartAiming()
        {
            if (_recoilProcessor.Value > 0)
                return;
            _gunSpread.Aiming = true;
        }

        public void StopAiming() => 
            _gunSpread.Aiming = false;

        public void Kick(float value)
        {
            StopAiming();
            _recoilProcessor.Kick(value);
        }
    }
}