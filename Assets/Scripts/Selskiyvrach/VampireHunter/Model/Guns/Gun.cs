using Selskiyvrach.VampireHunter.Model.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Gun
    {
        private readonly IMagazine _magazine;
        private readonly Damage _damage;

        public bool HammerCocked { get; private set; }
        public MagazineStatus MagazineStatus => _magazine.Status;
        public float Spread { get; set; }

        public Gun(IMagazine magazine, Damage damage)
        {
            _magazine = magazine;
            _damage = damage;
        }

        public void CockHammer() =>
            HammerCocked = true;
        
        public void PullTheTrigger(Ray trajectory)
        {
            var launchData = new BulletLaunchData(_damage, trajectory);
            _magazine.PopBullet().Launch(launchData);
        }

        public void LoadBullet() => 
            _magazine.LoadBullet();

        public void FullyLoad() => 
            _magazine.FullyLoad();
    }
}