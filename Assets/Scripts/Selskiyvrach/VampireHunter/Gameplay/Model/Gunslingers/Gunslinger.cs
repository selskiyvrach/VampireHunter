using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;
using Selskiyvrach.VampireHunter.Gameplay.Model.Spreads;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers
{
    public class Gunslinger : ITickable
    {
        private SpreadCalculator _spreadCalculator;
        private readonly Eyes _eyes;
        private readonly IRecoilProcessingSettings _recoilProcessingSettings;

        public bool FullyAimed => _spreadCalculator.FullyAimed;
        public Ray LookRay => _eyes.GetLookRay();
        public Spread GunSpread => _spreadCalculator.Spread;
        public Gun Gun { get; private set; }

        public Gunslinger(Eyes eyes, IRecoilProcessingSettings recoilProcessingSettings)
        {
            _eyes = eyes;
            _recoilProcessingSettings = recoilProcessingSettings;
        }

        public void Tick(float deltaTime) => 
            _spreadCalculator.Tick(deltaTime);

        public void SetGun(Gun gun)
        {
            Gun = gun;
            _spreadCalculator ??= new SpreadCalculator(gun, _recoilProcessingSettings);
            _spreadCalculator.ChangeGun(gun);
        }

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
            _eyes.RotateLook(delta);
            Gun.Point(_eyes.GetLookRay());
        }
    }
}