using UnityEngine;

namespace Selskiyvrach.Core.Unity.GizmosDrawers
{
    public abstract class GizmosDrawer : MonoBehaviour
    {
        [SerializeField] private bool _show = true;
        [SerializeField] private Color _color = Color.white;

        private void OnDrawGizmos()
        {
            if (!_show)
                return;
            Gizmos.color = _color;
            Draw();
        }

        protected abstract void Draw();
    }
}