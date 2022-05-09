using Selskiyvrach.VampireHunter.Model.Combat;
using Selskiyvrach.VampireHunter.Model.Guns;
using Bullet = Selskiyvrach.VampireHunter.View.Combat.Bullet;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class BulletAdapter : IBullet
    {
        private Bullet _bullet;

        public Damage Damage { get; private set; }

        public BulletAdapter(Bullet bullet) =>
            _bullet = bullet;

        public void Launch(BulletLaunchData launchData) =>
            _bullet.Launch(launchData.Trajectory.ToUnity(), launchData.bulletSpeed.Value);
    }
}