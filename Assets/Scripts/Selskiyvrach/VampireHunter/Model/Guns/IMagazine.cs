namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IMagazine : IReloadable, IMagazineStatus
    {
        IBullet PopBullet();
    }
}