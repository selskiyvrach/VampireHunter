using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.Core.Unity.Zenject;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals
{
    public class Arsenal
    {
        private readonly List<GunConfig> _gunConfigs;
        private readonly List<Ammo> _ammoPerGun;
        private readonly List<Gun> _guns;
        public IReadOnlyList<Gun> Guns => _guns;

        public Arsenal(GunConfig[] configs)
        {
            _gunConfigs = new List<GunConfig>(configs);
            _ammoPerGun = _gunConfigs.Select(CreateAmmo).ToList();
            _guns = _gunConfigs.Select(CreateGun).ToList();
            _guns.ForEach(RefillMagazine);
        }

        public void Load(Gun gun)
        {
            var gunIndex = _guns.IndexOf(gun);
            var ammo = _ammoPerGun[gunIndex];
            gun.Load(ammo);
        }

        public void RefillMagazine(Gun gun)
        {
            var gunIndex = _guns.IndexOf(gun);
            var ammo = _ammoPerGun[gunIndex];
            gun.RefillMagazine(ammo);
        }

        private static Gun CreateGun(GunConfig config) => 
            new Gun(config.Settings);

        private static Ammo CreateAmmo(GunConfig config) => 
            new Ammo(Enumerable.Range(1, config.Ammo).Select(n => new Bullet()));
    }
}