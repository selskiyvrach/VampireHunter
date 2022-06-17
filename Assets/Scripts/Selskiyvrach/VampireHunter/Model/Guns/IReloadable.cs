using Selskiyvrach.VampireHunter.Model.Arsenals;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IReloadable
    {
        void Load(Ammo ammo);
    }
}