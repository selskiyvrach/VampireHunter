namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    public interface IBullet
    {
        float Damage { get; }
        void Launch(BulletLaunchData launchData);
    }
}