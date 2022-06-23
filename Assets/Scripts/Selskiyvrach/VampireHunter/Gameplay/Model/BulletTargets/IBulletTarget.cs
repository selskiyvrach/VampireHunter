using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public interface IBulletTarget
    {
        public void GetHitBy(IBullet bullet);
    }
}