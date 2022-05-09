using System;
using Selskiyvrach.Core.Maths;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IRaycaster
    {
        RaycastResult Raycast(Ray ray, float maxDist = Single.MaxValue);
    }

    public struct RaycastResult
    {
        public readonly bool HasHit;
        public readonly Vector3 HitPos;

        public RaycastResult(bool hasHit, Vector3 hitPos)
        {
            HasHit = hasHit;
            HitPos = hitPos;
        }
    }
}