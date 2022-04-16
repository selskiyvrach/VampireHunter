using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class Gun : ITickable
    {
        private readonly StateMachine _gunStateMachine;
        private readonly GunAnimationsPlayer _gunAnimationsPlayer;

        public Gun(StateMachine gunStateMachine, GunAnimationsPlayer gunAnimationsPlayer)
        {
            _gunStateMachine = gunStateMachine;
            _gunAnimationsPlayer = gunAnimationsPlayer;
        }

        public void Tick(float deltaTime) =>
            _gunStateMachine.Tick(deltaTime);

        public void SetParentToTransform(Transform parent)
        {
            _gunAnimationsPlayer.transform.SetParent(parent);
        }
    }
}
