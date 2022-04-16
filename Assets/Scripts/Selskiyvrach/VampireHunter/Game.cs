using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class Game : MonoBehaviour
    {
        [SerializeField] 
        private GunFactory _gunFactory;

        [SerializeField] 
        private Transform _gunHolder;
        
        private Gun _gun;
        
        private void Start()
        {
            _gun = _gunFactory.Create();
            _gun.SetParentToTransform(_gunHolder);
        }

        private void Update()
        {
            _gun.Tick(Time.deltaTime);
        }
    }

}


