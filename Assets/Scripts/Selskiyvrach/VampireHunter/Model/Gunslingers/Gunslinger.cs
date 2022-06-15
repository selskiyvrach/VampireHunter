using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Spreads;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger
    {
        private readonly SpreadCalculator _spreadCalculator;
        private readonly EyeSight _eyeSight;
        private Gun _gun;

        public bool FullyAimed => _spreadCalculator.FullyAimed;
        public Spread? Spread => _gun != null 
            ? (Spread?)null 
            : _spreadCalculator.Spread;
        
        public Ray LookRay => _eyeSight.GetLookRay();

        public Gunslinger(SpreadCalculatorFactory spreadCalculatorFactory, EyeSight eyeSight)
        {
            _eyeSight = eyeSight;
            _spreadCalculator = spreadCalculatorFactory.Create();
        }

        public void Shoot()
        {
            var recoil = _gun.PullTheTrigger();
            _spreadCalculator.Kick(recoil.Amount);
        }

        public void SetGun(Gun gun)
        {
            _gun = gun;
            _spreadCalculator.SetGun(gun);
        }

        public void StartAiming() =>
            _spreadCalculator.StartAiming();

        public void StopAiming() => 
            _spreadCalculator.StopAiming();

        public void AdjustAimDirection(Vector2 delta)
        {
            _eyeSight.RotateLook(delta);
            _gun.Point(_eyeSight.GetLookRay());
        }
    }
}