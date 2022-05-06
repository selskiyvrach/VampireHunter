using Selskiyvrach.Core.Math;
using Selskiyvrach.VampireHunter.Model.Combat;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IBullet
    {
        Damage Damage { get; }
        void Launch(BulletLaunchData launchData);
    }

    public readonly struct BulletLaunchData
    {
        public readonly Damage Damage;
        public readonly Speed Speed;
        public readonly Ray Trajectory;

        public BulletLaunchData(Damage damage, Speed speed, Ray trajectory)
        {
            Damage = damage;
            Speed = speed;
            Trajectory = trajectory;
        }
    }

    public readonly struct Speed
    {
        public readonly float Value;

        public Speed(float value)
        {
            Value = value;
        }
    }
}