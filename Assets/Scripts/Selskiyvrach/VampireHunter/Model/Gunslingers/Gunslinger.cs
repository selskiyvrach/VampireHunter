using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Spreads;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger
    {
        private readonly SpreadCalculator _spreadCalculator;
        private readonly ArsenalOperator _arsenalOperator = new ArsenalOperator();
        private readonly EyeSight _eyeSight;

        public Gun Gun => _arsenalOperator.CurrentGun;
        public IReadOnlyList<Gun> Guns => _arsenalOperator.Guns;
        public bool FullyAimed => _spreadCalculator.FullyAimed;
        public Spread Spread => _spreadCalculator.Spread;
        public Ray LookRay => _eyeSight.GetLookRay();

        public Gunslinger(SpreadCalculatorFactory spreadCalculatorFactory, EyeSight eyeSight)
        {
            _eyeSight = eyeSight;
            _spreadCalculator = spreadCalculatorFactory.Create();
        }

        public void ChangeGun(int index) =>
            _arsenalOperator.ChangeGun(index);

        public void Shoot()
        {
            var recoil = Gun.PullTheTrigger();
            _spreadCalculator.Kick(recoil.Amount);
        }

        public void StartAiming() =>
            _spreadCalculator.StartAiming();

        public void StopAiming() => 
            _spreadCalculator.StopAiming();

        public void AdjustAimDirection(Vector2 delta)
        {
            _eyeSight.RotateLook(delta);
            Gun.Point(_eyeSight.GetLookRay());
        }
    }
}