namespace Selskiyvrach.VampireHunter.Combat.Guns
{
    public interface IMagazineData
    {
        int Capacity { get; }
    }

    public interface IMagazineStatus
    {
        int CurrentLoad { get; }
    }
}