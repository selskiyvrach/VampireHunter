using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.EditorGizmos
{
    public abstract class GizmosDrawer : MonoBehaviour
    {
        [SerializeField] private bool _show;
        [SerializeField] private Color _color;

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