using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Bullets
{
    public class BulletRaycaster : IBulletRaycaster
    {
        private static readonly RaycastHit[] Hits = new RaycastHit[50];
        
        public IBulletTarget RaycastBulletTarget(Ray ray)
        {
            var hitsCount = Physics.RaycastNonAlloc(ray, Hits);
            for (var i = 0; i < hitsCount; i++)
            {
                var target = Hits[i].collider.gameObject.GetComponent<IBulletTarget>(); 
                if (target != null)
                    return target;
            }
            return null;
        }
    }
}