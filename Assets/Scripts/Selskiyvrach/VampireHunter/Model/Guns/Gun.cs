using Selskiyvrach.VampireHunter.Model.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Gun
    {
        private readonly IMagazine _magazine;
        public bool HammerCocked { get; private set; }
        public MagazineStatus MagazineStatus => _magazine.Status;
        public float Spread { get; private set; }

        public Gun(IMagazine magazine) =>
            _magazine = magazine;

        public void CockHammer() =>
            HammerCocked = true;
        
        public void PullTheTrigger(Ray trajectory)
        {
            var launchData = new BulletLaunchData(new Damage(10), trajectory);
            _magazine.PopBullet().Launch(launchData);
        }
    }
}