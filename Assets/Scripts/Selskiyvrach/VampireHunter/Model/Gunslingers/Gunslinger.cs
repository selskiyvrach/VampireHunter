using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Model.Aiming;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Spread;
using UniRx;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger
    {
        private readonly SpreadCalculator _spreadCalculator;
        private readonly ArsenalOperator _arsenalOperator = new ArsenalOperator();
        private readonly GunOperator _gunOperator = new GunOperator();
        private readonly EyeSight _eyeSight;

        public IReadOnlyReactiveProperty<float> OnRecoilKicked => _gunOperator.OnRecoilKicked;
        public IReadOnlyList<Gun> Guns => _arsenalOperator.Guns;
        public MagazineStatus MagazineStatus => _gunOperator.MagazineStatus;
        public float SpreadDegrees => _spreadCalculator.Spread;
        public float Spread => _spreadCalculator.Spread;
        public bool HammerCocked => _gunOperator.HammerCocked;
        public bool FullyAimed => _spreadCalculator.FullyAimed;
        public Ray LookRay => _eyeSight.GetLookRay();

        public Gunslinger(SpreadCalculatorFactory spreadCalculatorFactory, EyeSight eyeSight)
        {
            _eyeSight = eyeSight;
            _spreadCalculator = spreadCalculatorFactory.Create();
        }

        public void ChangeGun(int index) =>
            _arsenalOperator.ChangeGun(index);

        public void Reload() => 
            _gunOperator.Reload();
        
        public void Shoot() => 
            _gunOperator.Shoot();

        public void StartAiming() =>
            _spreadCalculator.StartAiming();

        public void StopAiming() => 
            _spreadCalculator.StopAiming();

        public void AdjustAimDirection(Vector2 delta) => 
            _eyeSight.RotateLook(delta);
    }
}