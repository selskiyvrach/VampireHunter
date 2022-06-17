using Selskiyvrach.VampireHunter.Model.Arsenals;
using Selskiyvrach.VampireHunter.Model.Combat;
using Selskiyvrach.VampireHunter.Model.Guns.Settings;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Gun
    {
        private readonly IMagazine _magazine;
        private Ray _pointingRay;

        public IGunSettings Settings { get; }
        public bool HammerCocked { get; private set; }
        public MagazineStatus MagazineStatus => _magazine.Status;

        public Gun(IGunSettings settings)
        {
            _magazine = new SixRoundDrum(settings.MagazineSettings.Capacity);
            Settings = settings;
        }

        public void CockHammer() => 
            HammerCocked = true;

        public void Point(Ray ray) =>
            _pointingRay = ray;

        public Recoil PullTheTrigger()
        {
            HammerCocked = false;
            var launchData = new BulletLaunchData(new Damage(Settings.Damage), _pointingRay);
            _magazine.PopBullet().Launch(launchData);
            return new Recoil(Settings.RecoilSettings.Recoil);
        }

        public void Load(Ammo ammo) => 
            _magazine.Load(ammo);
    }
}