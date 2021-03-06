using Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public class Gun
    {
        private readonly IMagazine _magazine;
        private Ray _pointingRay;

        public int ConfigID { get; }
        public IGunSettings Settings { get; }
        public bool HammerCocked { get; private set; }
        public MagazineStatus MagazineStatus => _magazine.Status;
        public Transform Transform { get; }

        public Gun(IGunSettings settings, int configID)
        {
            _magazine = new Drum(settings.MagazineSettings.Capacity);
            Settings = settings;
            ConfigID = configID;
            Transform = new GameObject("Gun").transform;
        }
        
        public void CockHammer() => 
            HammerCocked = true;

        public void Point(Ray ray) =>
            _pointingRay = ray;

        public Recoil PullTheTrigger()
        {
            HammerCocked = false;
            var launchData = new BulletLaunchData(Settings.Damage, _pointingRay);
            _magazine.PopBullet().Launch(launchData);
            return new Recoil(Settings.RecoilSettings.Recoil);
        }

        public void Load(Ammo ammo) => 
            _magazine.Reload(ammo);

        public void RefillMagazine(Ammo ammo) => 
            _magazine.Refill(ammo);
    }
}