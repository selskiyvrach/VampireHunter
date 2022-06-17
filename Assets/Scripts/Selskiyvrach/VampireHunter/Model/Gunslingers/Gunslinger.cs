using System.Runtime.InteropServices;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Spreads;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger : ITickable
    {
        private SpreadCalculator _spreadCalculator;
        private readonly EyeSight _eyeSight;
        private Gun _gun;

        public bool FullyAimed => _spreadCalculator.FullyAimed;
        public Ray LookRay => _eyeSight.GetLookRay();

        public Gunslinger(EyeSight eyeSight) => 
            _eyeSight = eyeSight;

        public void Tick(float deltaTime) => 
            _spreadCalculator.Tick(deltaTime);

        public void Shoot()
        {
            var recoil = _gun.PullTheTrigger();
            _spreadCalculator.Kick(recoil.Amount);
        }

        public void SetGun(Gun gun)
        {
            _gun = gun;
            _spreadCalculator ??= new SpreadCalculator(gun);
            _spreadCalculator.ChangeGun(gun);
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