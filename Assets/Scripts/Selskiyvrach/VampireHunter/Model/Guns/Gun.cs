using Selskiyvrach.VampireHunter.Model.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Gun
    {
        private readonly IMagazine _magazine;
        private Ray _pointingRay;

        public IGunStats Stats { get; }
        public bool HammerCocked { get; private set; }
        public MagazineStatus MagazineStatus => _magazine.Status;

        public Gun(IGunStats stats)
        {
            _magazine = new Magazine(stats.MagazineCapacity);
            Stats = stats;
        }

        public void CockHammer() => 
            HammerCocked = true;

        public void Point(Ray ray) =>
            _pointingRay = ray;

        public Recoil PullTheTrigger()
        {
            HammerCocked = false;
            var launchData = new BulletLaunchData(new Damage(Stats.Damage), _pointingRay);
            _magazine.PopBullet().Launch(launchData);
            return new Recoil(Stats.Recoil);
        }
    }
}