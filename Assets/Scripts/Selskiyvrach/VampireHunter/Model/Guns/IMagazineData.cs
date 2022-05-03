using System;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IMagazineData
    {
        int Capacity { get; }
    }

    public interface IMagazineStatus
    {
        int CurrentLoad { get; }
        event Action<IntDelta> OnLoadChanged;
    }

    public struct IntDelta
    {
        public readonly int Value;

        public IntDelta(int value)
        {
            Value = value;
        }
    }
}