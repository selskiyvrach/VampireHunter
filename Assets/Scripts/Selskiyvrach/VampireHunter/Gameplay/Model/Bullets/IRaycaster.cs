using Selskiyvrach.Core.Unity.Physics;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    public interface IRaycaster
    {
        T Raycast<T>(Ray ray) where T :class, IRaycastable;
    }
}