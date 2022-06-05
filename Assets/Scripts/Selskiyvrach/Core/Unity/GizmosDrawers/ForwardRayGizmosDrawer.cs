using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.Core.Unity.GizmosDrawers
{
    public class ForwardRayGizmosDrawer : GizmosDrawer
    {
        [MinValue(1)]
        [SerializeField] private float _distance = 10;
        
        protected override void Draw()
        {
            var position = transform.position;
            Gizmos.DrawLine(position, position + transform.forward * _distance);
        }
    }
}