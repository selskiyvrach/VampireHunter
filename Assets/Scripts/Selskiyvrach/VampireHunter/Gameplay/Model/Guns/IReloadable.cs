using Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public interface IReloadable
    {
        void Reload(Ammo ammo);
        void Refill(Ammo ammo);
    }
}