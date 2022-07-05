using System;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public interface IBulletTargetComponent
    {
        public bool AddBulletTarget(IBulletTarget target);
        public bool RemoveBulletTarget(IBulletTarget target);
        void Enable();
        void Disable();
    }
}