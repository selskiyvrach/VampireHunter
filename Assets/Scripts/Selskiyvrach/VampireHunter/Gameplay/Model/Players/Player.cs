using System.Linq;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.Core.Unity.Physics;
using Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Spreads;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Players
{
    public class Player : ITickable
    {
        private readonly Raycaster _raycaster = new Raycaster(nonAllocHitsArraySize: 20);
        private readonly ITouchInput _touchInput;
        private readonly Gunslinger _gunslinger;
        private readonly Arsenal _arsenal;
        private readonly ITicker _ticker;

        public Spread GunSpread => _gunslinger.GunSpread;
        public Gun Gun => _gunslinger.Gun;

        public Player(ITouchInput touchInput, Gunslinger gunslinger, Arsenal arsenal, ITicker ticker)
        {
            _touchInput = touchInput;
            _gunslinger = gunslinger;
            _arsenal = arsenal;
            _ticker = ticker;
            
            _ticker.AddTickable(_gunslinger);
            _ticker.AddTickable(this);
            
            _gunslinger.SetGun(_arsenal.Guns.First());
        }

        public void Tick(float deltaTime)
        {
            if (!_touchInput.Held())
                _gunslinger.StopAiming();
            else if(!_gunslinger.FullyAimed)
                _gunslinger.StartAiming();
            
            if(_gunslinger.FullyAimed && _gunslinger.Gun.MagazineStatus.Any && _raycaster.Raycast<IBulletTarget>(_gunslinger.LookRay) != null)
                _gunslinger.Shoot();

            _gunslinger.AdjustAimDirection(_touchInput.Delta());
        }
    }
}