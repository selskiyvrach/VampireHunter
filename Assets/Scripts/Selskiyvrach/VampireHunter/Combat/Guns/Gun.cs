using System.Collections.Generic;
using System.Threading.Tasks;
using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.Combat.Guns
{
    public class Gun : ITickable, ILateTickable, IRecoilData
    {
        private readonly IMagazine _magazine;
        private readonly ISight _sight;
        private readonly ITrigger _trigger;
        
        private bool _pullTrigger;
        private bool _cockTrigger;
        
        private readonly StateMachine _stateMachine = new StateMachine();
        
        public int Recoil { get; }
        public int CurrentRecoil { get; private set; }

        public Gun(IMagazine magazine, ISight sight, ITrigger trigger)
        {
            _magazine = magazine;
            _sight = sight;
            _trigger = trigger;

            var triggerPulledCondition = new FuncCondition(() => _pullTrigger);
            var isCockedCondition = new FuncCondition(() => _trigger.IsCocked);
            var cockTriggerCondition = new FuncCondition(() => _cockTrigger && !_trigger.IsCocked);
            var anyBulletsCondition = new FuncCondition(() => _magazine.CurrentLoad > 0); 
            var canShootCondition = new CompositeCondition(new List<ICondition>()
            {
                anyBulletsCondition,
                isCockedCondition, 
                triggerPulledCondition
            });
            
            var fireBulletAction = new ActionAction(() => _magazine.Pop().SetTrajectory(_sight.GetShotProjection()).Launch());
            var generateRecoilAction = new ActionAction(() => CurrentRecoil = Recoil);

            var stateBuilder = new StateBuilder();

            var idleState = stateBuilder
                .OnEnter(new DebugLogAction("idle"))
                .Build();

            stateBuilder.Reset();

            var cockTriggerState = stateBuilder
                .OnEnter(new DebugLogAction("enter cock"))
                .OnEnter(new ActionAction(async () => { await Task.Delay(1000); _trigger.Cock(); }))
                .OnExit(new DebugLogAction("exit cock"))
                .Build();
            stateBuilder.Reset();

            var shootState = stateBuilder
                .OnEnter(new ActionAction(() => _trigger.Pull()))
                .OnEnter(fireBulletAction)
                .OnEnter(new DebugLogAction("shoot"))
                .OnEnter(generateRecoilAction)
                .Build();
            stateBuilder.Reset();
            
            idleState.AddTransition(shootState, canShootCondition);
            idleState.AddTransition(cockTriggerState, cockTriggerCondition);
            cockTriggerState.AddTransition(idleState, new FuncCondition(() => _trigger.IsCocked));
            shootState.AddTransition(idleState, new TrueCondition());
            
            _stateMachine.StartState(idleState);
        }

        public void PullTheTrigger()
        {
            _pullTrigger = true;
        }

        public void AbsorbRecoil()
        {
            CurrentRecoil = 0;
        }

        public void CockTheTrigger()
        {
            _cockTrigger = true;
        }

        void ITickable.Tick(float deltaTime)
        {
            _stateMachine.Tick(deltaTime);            
        }

        void ILateTickable.Tick(float deltaTime)
        {
            _pullTrigger = false;
            _cockTrigger = false;
        }
    }
}
