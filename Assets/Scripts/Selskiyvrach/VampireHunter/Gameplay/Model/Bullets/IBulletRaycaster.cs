using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    public interface IBulletRaycaster
    {
        IBulletTarget RaycastBulletTarget(Ray ray);
    }
}