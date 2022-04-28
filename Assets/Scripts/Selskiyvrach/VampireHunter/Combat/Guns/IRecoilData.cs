namespace Selskiyvrach.VampireHunter.Combat.Guns
{
    public interface IRecoilData
    {
        int Recoil { get; }
        int CurrentRecoil { get; }
    }
}