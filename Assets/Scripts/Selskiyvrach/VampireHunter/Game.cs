using System;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class Game : MonoBehaviour
    {
        [SerializeField] 
        private GunFactory _gunFactory;

        [SerializeField] 
        private Transform _gunHolder;

        [SerializeField] 
        private CameraMoverFactory _cameraMoverFactory;
        
        [SerializeField] 
        private MouseGunInput _gunInput;

        private Gun _gun;
        private CameraMover _cameraMover;
        
        private void Start()
        {
            _gun = _gunFactory.Create();
            _gun.SetParentToTransform(_gunHolder);

            _cameraMover = _cameraMoverFactory.Create();
        }

        private void Update()
        {
            _gun.Tick(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _cameraMover.Move(_gunInput.AimDelta());
        }
    }
}


