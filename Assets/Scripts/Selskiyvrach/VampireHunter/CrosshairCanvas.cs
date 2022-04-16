using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class CrosshairCanvas : MonoBehaviour
    {
        [SerializeField] 
        private RectTransform _crosshair;

        [SerializeField] 
        private CanvasGroup _canvasGroup;

        public RectTransform Crosshair => _crosshair;
        public CanvasGroup CanvasGroup => _canvasGroup;
    }
}