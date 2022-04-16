
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class CrosshairFactory : MonoBehaviour
    {
        [SerializeField] 
        private CrosshairCanvas _crosshairPrefab;
        
        public ICrosshair Create()
        {
            var canvas = Instantiate(_crosshairPrefab);
            return new Crosshair(canvas.Crosshair, canvas.CanvasGroup);
        }
    }
}