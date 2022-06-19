using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public interface IBullet
    {
        Damage Damage { get; }
        void Launch(BulletLaunchData launchData);
    }
}