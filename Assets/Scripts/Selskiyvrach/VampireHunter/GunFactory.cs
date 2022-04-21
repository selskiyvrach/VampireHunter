using System.Collections.Generic;
using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.StateMachines;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class GunFactory : MonoBehaviour
    {
        [SerializeField] 
        private CrosshairFactory _crosshairFactory;

        [SerializeField] 
        private RecoilAnimationPlayer _gunPrefab;

        [SerializeField] 
        private RecoilAnimationPlayer _cameraRecoil;

        [SerializeField] 
        private MouseGunInput _gunInput;

        [SerializeField] 
        private CameraMoverFactory _cameraMoverFactory;

        [SerializeField] 
        private Camera _camera;
        
        public Gun Create()
        {
            var crosshair = _crosshairFactory.Create();
            var gunAnimationPlayer = Instantiate(_gunPrefab);

            var stateBuilder = new StateBuilder();

            var idleState = stateBuilder
                .OnEnter(new ZoomOutAction(_cameraMoverFactory.CreateOrGetCashed()))
                .OnEnter(new TransitionCrosshairToIdle(crosshair))
                .Build();
            stateBuilder.Reset();

            var aimState = stateBuilder
                .OnEnter(new ZoomInAction(_cameraMoverFactory.CreateOrGetCashed()))
                .OnEnter(new TransitionCrosshairToAimed(crosshair))
                .Build();
            stateBuilder.Reset();

            var shootState = stateBuilder
                .Build();
            stateBuilder.Reset();

            var recoilState = stateBuilder
                .OnEnter(new TransitionCrosshairToRecoil(crosshair))
                .OnEnter(new PlayRecoilAnimationAction(gunAnimationPlayer))
                .OnEnter(new PlayRecoilAnimationAction(_cameraRecoil))
                .Build();
            stateBuilder.Reset();

            var isAimingCondition = new IsAimInputDownCondition(_gunInput);
            var hasShotCondition = new TrueCondition();
            var isIdledCondition = new IsIdledCondition(crosshair);
            var canShootCondition = new CompositeCondition(new List<ICondition>()
            {
                new CrosshairCenteredCondition(crosshair),
                new GunPointedAtTargetCondition( crosshair.ScreenPos, _camera)                
            });

            idleState.AddTransition(aimState, isAimingCondition);
            aimState.AddTransition(shootState, canShootCondition);
            aimState.AddTransition(idleState, new NegatorCondition(isAimingCondition));
            shootState.AddTransition(recoilState, hasShotCondition);
            recoilState.AddTransition(idleState, isIdledCondition);

            var stateMachine = new StateMachine(idleState);
            return new Gun(stateMachine, gunAnimationPlayer);
        }
    }
}