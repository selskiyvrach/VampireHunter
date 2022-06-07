using UnityEngine;

namespace Selskiyvrach.VampireHunter.View.Crosshair
{
    public class Crosshair : MonoBehaviour, ICrosshair
    {
        [SerializeField] private RectTransform _crosshair;

        public void Show()
        {
        }

        public void Hide()
        {
        }

        public void SetRadius(float pixels) => 
            _crosshair.sizeDelta = new Vector2(pixels, pixels);
    }
}