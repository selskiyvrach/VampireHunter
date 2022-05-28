using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Stats;
using Selskiyvrach.VampireHunter.Unity.Combat;

namespace Selskiyvrach.VampireHunter.Controller.Guns
{
    public class BulletAdapter : IBullet
    {
        private Bullet _bullet;

        public Damage Damage { get; private set; }

        public BulletAdapter(Bullet bullet) =>
            _bullet = bullet;

        public void Launch(BulletLaunchData launchData) =>
            _bullet.Launch(launchData.Trajectory.ToUnity());
    }
}