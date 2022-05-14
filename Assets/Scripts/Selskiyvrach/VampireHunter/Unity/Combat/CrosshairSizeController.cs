using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Unity.EditorGizmos;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Combat
{
    [ExecuteAlways]
    public class CrosshairSizeController : MonoBehaviour
    {
        [SerializeField] private SpreadConeGizmos _coneGizmos;
        [SerializeField] private RectTransform _crosshair;
        [SerializeField] private Camera _camera;
        
        [Button]
        private void LateUpdate()
        {
            var cone = _coneGizmos.Cone;
            var topPoint = cone.GetPointOnBaseCircle(0).ToUnity();
            var bottomPoint = cone.GetPointOnBaseCircle(180).ToUnity();
            var topPointProjection = _camera.WorldToScreenPoint(topPoint);
            var bottomPointProjection = _camera.WorldToScreenPoint(bottomPoint);
            var sizeDelta = Vector2.Distance(topPointProjection, bottomPointProjection);
            _crosshair.sizeDelta = new Vector2(sizeDelta, sizeDelta);
        }
    }
}