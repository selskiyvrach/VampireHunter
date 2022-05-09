using Selskiyvrach.Core.Maths;
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
        public readonly BulletSpeed bulletSpeed;
        public readonly Ray Trajectory;

        public BulletLaunchData(Damage damage, BulletSpeed bulletSpeed, Ray trajectory)
        {
            Damage = damage;
            this.bulletSpeed = bulletSpeed;
            Trajectory = trajectory;
        }
    }

    public readonly struct BulletSpeed
    {
        public readonly float Value;

        public BulletSpeed(float value)
        {
            Value = value;
        }
    }
}