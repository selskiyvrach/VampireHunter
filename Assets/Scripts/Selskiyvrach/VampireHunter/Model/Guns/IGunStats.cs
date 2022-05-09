using Selskiyvrach.VampireHunter.Model.Combat;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IGunStats : IAccuracyProvider
    {
        BulletSpeed BulletSpeed { get;}
        Damage Damage { get; }
        Recoil Recoil { get; }
    }

    public struct Recoil
    {
        public readonly int Value;

        public Recoil(int value)
        {
            Value = value;
        }
    }
}