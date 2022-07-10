using Selskiyvrach.Core.Unity.Physics;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    //TODO: put bullets into pool
    public class RaycastBullet : IBullet
    {
        private static readonly IRaycaster Raycaster = new Raycaster();
        public float Damage { get; private set; }

        public void Launch(BulletLaunchData launchData)
        {
            Damage = launchData.Damage;
            Raycaster.Raycast<IBulletTarget>(launchData.Trajectory)?.GetHitBy(this);
        }
    }
}