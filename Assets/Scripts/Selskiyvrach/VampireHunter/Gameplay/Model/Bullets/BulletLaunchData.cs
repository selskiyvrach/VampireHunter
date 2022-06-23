using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    public readonly struct BulletLaunchData
    {
        public readonly int Damage;
        public readonly Ray Trajectory;

        public BulletLaunchData(int damage, Ray trajectory)
        {
            Damage = damage;
            Trajectory = trajectory;
        }
    }
}