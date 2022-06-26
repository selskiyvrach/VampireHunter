using System;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public abstract class BulletTargetComponent : MonoBehaviour, IBulletTarget
    {
        public event Action<HitInfo> OnHit;
        public abstract void GetHitBy(IBullet bullet);
        protected void RaiseOnHit(HitInfo info) => 
            OnHit?.Invoke(info);
    }
}