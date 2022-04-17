using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class CameraMoverFactory : MonoBehaviour
    {
        [SerializeField] 
        private Vector2 _clampX;

        [SerializeField] 
        private Vector2 _clampY;

        [SerializeField] 
        private Vector2 _speedRatio;
        
        [SerializeField] 
        private Camera _camera;

        private CameraMover _cashed;

        public CameraMover CreateOrGetCashed()
        {
            return _cashed ??= new CameraMover(_camera, _clampX, _clampY, _speedRatio);
        }
    }
}