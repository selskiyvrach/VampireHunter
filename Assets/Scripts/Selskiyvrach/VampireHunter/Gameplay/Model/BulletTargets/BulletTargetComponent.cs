using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public abstract class BulletTargetComponent : MonoBehaviour, IBulletTarget
    {
        public abstract void GetHitBy(IBullet bullet);
    }
}