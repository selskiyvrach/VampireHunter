using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public struct HitInfo
    {
        public IBullet Bullet { get; }

        public HitInfo(IBullet bullet) => 
            Bullet = bullet;
    }
}