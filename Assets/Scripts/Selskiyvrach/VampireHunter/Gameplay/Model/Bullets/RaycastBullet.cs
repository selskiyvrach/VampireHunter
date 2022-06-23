namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    public class RaycastBullet : IBullet
    {
        private readonly IBulletRaycaster _raycaster = new BulletRaycaster();
        public int Damage { get; private set; }

        public void Launch(BulletLaunchData launchData)
        {
            Damage = launchData.Damage;
            _raycaster.RaycastBulletTarget(launchData.Trajectory)?.GetHitBy(this);
            //TODO: put into pool
        }
    }
}