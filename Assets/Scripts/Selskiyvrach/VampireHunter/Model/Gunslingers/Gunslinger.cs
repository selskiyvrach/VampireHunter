using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Model.Aiming.Spread;
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
        private readonly SpreadController _spreadController;
        
        public MagazineStatus MagazineStatus => _gunOperator.MagazineStatus;
        public bool HammerCocked => _gunOperator.HammerCocked;
        public IReadOnlyList<Gun> Guns => _arsenalOperator.Guns;
        public IReadOnlyReactiveProperty<float> OnRecoilKicked => _gunOperator.OnRecoilKicked;
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
            _spreadController.StartAiming();

        public void StopAiming() => 
            _spreadController.StopAiming();

        // public void AdjustAimDirection(Vector2 delta) => 
        //     _spreadController.AdjustAimDirection(delta);
    }

    public class ArsenalOperator
    {
        private readonly Arsenal _arsenal = new Arsenal();

        public IReadOnlyList<Gun> Guns => _arsenal.Guns;
        public Gun CurrentGun { get; private set; }

        public void ChangeGun(int index) =>
            CurrentGun = _arsenal.GetGun(index);
    }

    public class GunOperator
    {
        private readonly ReactiveProperty<float> _onRecoilKicked = new ReactiveProperty<float>();
        public IReadOnlyReactiveProperty<float> OnRecoilKicked => _onRecoilKicked;

        public MagazineStatus MagazineStatus => _gun.MagazineStatus;
        public bool HammerCocked => _gun.HammerCocked;
        private Gun _gun;

        public void Shoot()
        {
        }

        public void Reload()
        {
        }
    }
}