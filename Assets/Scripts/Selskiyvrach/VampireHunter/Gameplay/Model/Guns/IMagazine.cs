using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public interface IMagazine : IReloadable, IMagazineStatus
    {
        IBullet PopBullet();
    }
}