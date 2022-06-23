namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    public interface IBullet
    {
        int Damage { get; }
        void Launch(BulletLaunchData launchData);
    }
}