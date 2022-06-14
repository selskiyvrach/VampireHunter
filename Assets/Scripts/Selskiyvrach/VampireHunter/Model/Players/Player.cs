using Selskiyvrach.Core.Maths;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.VampireHunter.Model.Aiming;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Players
{
    public class Player : ITickable, ISpreadConeProvider
    {
        private readonly ITouchInput _touchInput;
        private readonly Gunslinger _gunslinger;
        private readonly AimingSettings _aimingSettings;
        private readonly TouchSensitivitySettings _sensitivitySettings;
        private readonly ITicker _ticker;

        public Cone SpreadCone => new Cone(_gunslinger.Spread.AngleDegrees, _aimingSettings.MaxAimingDistance);

        public Player(
            ITouchInput touchInput, 
            Gunslinger gunslinger, 
            AimingSettings aimingSettings, 
            TouchSensitivitySettings sensitivitySettings, 
            ITicker ticker)
        {
            _touchInput = touchInput;
            _gunslinger = gunslinger;
            _aimingSettings = aimingSettings;
            _sensitivitySettings = sensitivitySettings;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            if (!_touchInput.Held())
                _gunslinger.StopAiming();
            else if(!_gunslinger.FullyAimed)
                _gunslinger.StartAiming();
            
            _gunslinger.AdjustAimDirection(_touchInput.Delta() * _sensitivitySettings.Sensitivity);
            
            if(Input.GetMouseButtonDown(1))
                _gunslinger.Shoot();
        }
    }
}