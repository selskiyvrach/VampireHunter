using Selskiyvrach.VampireHunter.Model.Combat;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Unity;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class GunStatsAdapter : IGunStats
    {
        private readonly GunStats _stats;

        public GunStatsAdapter(GunStats stats)
        {
            _stats = stats;
        }

        public BulletSpeed BulletSpeed => new BulletSpeed(_stats.BulletSpeed);
        public Damage Damage => new Damage(_stats.Damage);
        public Accuracy Accuracy => new Accuracy(_stats.Accuracy);
        public Recoil Recoil => new Recoil(_stats.Recoil);
    }
}