namespace Selskiyvrach.VampireHunter.Model.Guns
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