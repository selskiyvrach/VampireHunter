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
        private GunAnimationsPlayer _gunPrefab;

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
                .OnEnter(new DebugLogAction(">> idling"))
                .OnEnter(new ZoomOutAction(_cameraMoverFactory.CreateOrGetCashed()))
                .OnEnter(new TransitionCrosshairToIdle(crosshair))
                .OnExit(new DebugLogAction("<< idling"))
                .Build();
            stateBuilder.Reset();

            var aimState = stateBuilder
                .OnEnter(new DebugLogAction(">> aiming"))
                .OnEnter(new ZoomInAction(_cameraMoverFactory.CreateOrGetCashed()))
                .OnEnter(new TransitionCrosshairToAimed(crosshair))
                .OnExit(new DebugLogAction("<< aiming"))
                .Build();
            stateBuilder.Reset();

            var shootState = stateBuilder
                .OnEnter(new DebugLogAction(">> shooting"))
                .OnExit(new DebugLogAction("<< shooting"))
                .Build();
            stateBuilder.Reset();

            var recoilState = stateBuilder
                .OnEnter(new DebugLogAction(">> recoil"))
                .OnEnter(new TransitionCrosshairToRecoil(crosshair))
                .OnEnter(new PlayGunRecoilAnimationAction(gunAnimationPlayer))
                .OnExit(new DebugLogAction("<< recoil"))
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