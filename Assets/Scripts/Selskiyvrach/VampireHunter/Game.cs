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
            _gun.SetParent(_gunHolder);

            _cameraMover = _cameraMoverFactory.CreateOrGetCashed();
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


