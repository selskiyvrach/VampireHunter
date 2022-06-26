using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.View.Crosshairs
{
    public class Crosshair : MonoBehaviour, ICrosshair
    {
        [SerializeField] private RectTransform _crosshair;

        public void SetRadius(float pixels) => 
            _crosshair.sizeDelta = new Vector2(pixels, pixels);
    }
}