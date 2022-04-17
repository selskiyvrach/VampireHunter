using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class Gun : ITickable
    {
        private readonly StateMachine _gunStateMachine;
        private readonly RecoilAnimationPlayer _recoilAnimationPlayer;

        public Gun(StateMachine gunStateMachine, RecoilAnimationPlayer recoilAnimationPlayer)
        {
            _gunStateMachine = gunStateMachine;
            _recoilAnimationPlayer = recoilAnimationPlayer;
        }

        public void Tick(float deltaTime) =>
            _gunStateMachine.Tick(deltaTime);

        public void SetParent(Transform parent)
        {
            _recoilAnimationPlayer.transform.SetParent(parent);
            _recoilAnimationPlayer.transform.SetPositionAndRotation(parent.position, parent.rotation);
        }
    }
}
