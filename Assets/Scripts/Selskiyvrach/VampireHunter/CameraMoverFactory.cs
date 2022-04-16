using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class CameraMoverFactory : MonoBehaviour
    {
        [SerializeField] 
        private Camera _camera;

        public CameraMover Create()
        {
            return new CameraMover(_camera);
        }
    }
}