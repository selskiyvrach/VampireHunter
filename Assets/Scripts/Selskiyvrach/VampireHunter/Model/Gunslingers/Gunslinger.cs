using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Spread;
using UniRx;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger
    {
        private readonly ArsenalOperator _arsenalOperator = new ArsenalOperator();
        private readonly GunOperator _gunOperator = new GunOperator();
        private readonly SpreadCalculator _spreadCalculator;

        public Gunslinger(SpreadCalculatorFactory spreadCalculatorFactory)
        {
            _spreadCalculator = spreadCalculatorFactory.Create();
            
        }

        public MagazineStatus MagazineStatus => _gunOperator.MagazineStatus;
        public bool HammerCocked => _gunOperator.HammerCocked;
        public IReadOnlyList<Gun> Guns => _arsenalOperator.Guns;
        public IReadOnlyReactiveProperty<float> OnRecoilKicked => _gunOperator.OnRecoilKicked;
        public float SpreadDegrees => _spreadCalculator.Spread;
        // public Vector3 AimDirection => _spreadController.AimDirection;
        // public float CurrentAccuracy => _spreadController.CurrentSpread;
        // public bool FullyAimed => _spreadController.FullyAimed;
        
        public void ChangeGun(int index) => 
            _arsenalOperator.ChangeGun(index);

        public void Reload() => 
            _gunOperator.Shoot();
        
        public void Shoot() => 
            _gunOperator.Shoot();

        public void StartAiming() =>
            _spreadCalculator.StartAiming();

        public void StopAiming() => 
            _spreadCalculator.StopAiming();

        // public void AdjustAimDirection(Vector2 delta) => 
        //     _spreadController.AdjustAimDirection(delta);
    }
}