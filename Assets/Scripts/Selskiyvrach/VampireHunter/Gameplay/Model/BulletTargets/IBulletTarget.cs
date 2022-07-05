﻿using Selskiyvrach.Core.Unity.Physics;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public interface IBulletTarget : IRaycastable
    {
        public void GetHitBy(IBullet bullet);
    }
}