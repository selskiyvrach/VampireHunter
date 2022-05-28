using Selskiyvrach.VampireHunter.Model.Stats;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IGun : ITrigger, IReloadable, IMagazineStatus
    {
    }

    public class Gun : IGun
    {
        private readonly ISight _sight;
        private readonly ITrigger _trigger;
        private readonly IMagazine _magazine;
        private readonly Damage _damage = new Damage(10);

        public bool IsCocked => _trigger.IsCocked;
        public MagazineStatus Status => _magazine.Status;

        public Gun(IMagazine magazine, ITrigger trigger, ISight sight)
        {
            _magazine = magazine;
            _trigger = trigger;
            _sight = sight;
        }

        public void Cock() => 
            _trigger.Cock();

        public void Pull()
        {
            _trigger.Pull();
            var trajectory = _sight.GetBulletTrajectory();
            var launchData = new BulletLaunchData(_damage, trajectory);
            _magazine.PopBullet().Launch(launchData);
        }

        public void LoadBullet() => 
            _magazine.LoadBullet();

        public void FullyLoad() => 
            _magazine.FullyLoad();
    }
}