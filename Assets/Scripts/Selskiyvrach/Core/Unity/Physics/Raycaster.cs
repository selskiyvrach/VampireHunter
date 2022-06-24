using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using UnityEngine;

namespace Selskiyvrach.Core.Unity.Physics
{
    public class Raycaster : IRaycaster
    {
        private readonly RaycastHit[] _hits;

        public Raycaster(int nonAllocHitsArraySize = 50) => 
            _hits = new RaycastHit[nonAllocHitsArraySize];

        public T Raycast<T>(Ray ray) where T :class, IRaycastable
        {
            var hitsCount = UnityEngine.Physics.RaycastNonAlloc(ray, _hits);
            for (var i = 0; i < hitsCount; i++)
            {
                var target = _hits[i].collider.gameObject.GetComponent<T>(); 
                if (target != null)
                    return target;
            }
            return null;
        }
    }
}