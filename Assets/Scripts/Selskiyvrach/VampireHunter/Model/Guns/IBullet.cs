using Selskiyvrach.VampireHunter.Model.Combat;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IBullet
    {
        Damage Damage { get; }
        void Launch(BulletLaunchData launchData);
    }
}