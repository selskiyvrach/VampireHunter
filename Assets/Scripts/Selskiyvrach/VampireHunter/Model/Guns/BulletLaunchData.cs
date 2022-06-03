using Selskiyvrach.VampireHunter.Model.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public readonly struct BulletLaunchData
    {
        public readonly Damage Damage;
        public readonly Ray Trajectory;

        public BulletLaunchData(Damage damage, Ray trajectory)
        {
            Damage = damage;
            Trajectory = trajectory;
        }
    }
}