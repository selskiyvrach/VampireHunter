using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.StateMachines;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class GunFactory : MonoBehaviour
    {
        [SerializeField] private CrosshairFactory _crosshairFactory;

        [SerializeField] private GunAnimationsPlayer _gunPrefab;

        [SerializeField] private MouseGunInput _gunInput;

        public Gun Create()
        {
            var crosshair = _crosshairFactory.Create();
            var gunAnimationPlayer = Instantiate(_gunPrefab);

            var stateBuilder = new StateBuilder();

            var idleState = stateBuilder
                .OnEnter(new DebugLogAction(">> idling"))
                .OnEnter(new TransitionCrosshairToIdle(crosshair))
                .OnExit(new DebugLogAction("<< idling"))
                .Build();
            stateBuilder.Reset();

            var aimState = stateBuilder
                .OnEnter(new DebugLogAction(">> aiming"))
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
            var shootCondition = new CrosshairCenteredCondition(crosshair);
            var isIdledCondition = new IsIdledCondition(crosshair);

            idleState.AddTransition(aimState, isAimingCondition);
            aimState.AddTransition(shootState, shootCondition);
            shootState.AddTransition(recoilState, hasShotCondition);
            recoilState.AddTransition(idleState, isIdledCondition);

            var stateMachine = new StateMachine(idleState);
            return new Gun(stateMachine, gunAnimationPlayer);
        }
    }
}