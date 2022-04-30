using System.Collections.Generic;
using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Gun : ITickable, IRecoilData
    {
        private readonly IMagazine _magazine;
        private readonly ISight _sight;
        private readonly ITrigger _trigger;
        private readonly StateMachine _stateMachine = new StateMachine();

        private bool _pullTrigger;
        private bool _cockTrigger;

        public int Recoil { get; }
        public int CurrentRecoil { get; private set; }

        public Gun(IMagazine magazine, ISight sight, ITrigger trigger)
        {
            _magazine = magazine;
            _sight = sight;
            _trigger = trigger;
            
            var stateBuilder = new StateBuilder();

            var idleState = stateBuilder
                .Build();
            stateBuilder.Reset();

            var cockTriggerState = stateBuilder
                .OnEnter(new ActionAction(() => _trigger.Cock()))
                .Build();
            stateBuilder.Reset();

            var shootState = stateBuilder
                .OnEnter(new ActionAction(() => _trigger.Pull()))
                .OnEnter(new ActionAction(() => _magazine.Pop().SetTrajectory(_sight.GetShotProjection()).Launch()))
                .OnEnter(new ActionAction(() => CurrentRecoil = Recoil))
                .Build();
            stateBuilder.Reset();
            
            idleState.AddTransition(shootState, new CompositeCondition(new List<ICondition>()
            {
                new FuncCondition(() => _magazine.CurrentLoad > 0),
                new FuncCondition(() => _trigger.IsCocked),
                new FuncCondition(() => _pullTrigger)
            }));
            
            idleState.AddTransition(cockTriggerState, new FuncCondition(() => _cockTrigger && !_trigger.IsCocked));
            cockTriggerState.AddTransition(idleState, new FuncCondition(() => _trigger.IsCocked));
            shootState.AddTransition(idleState, new TrueCondition());
            
            _stateMachine.StartState(idleState);
        }

        public void PullTheTrigger() =>
            _pullTrigger = true;

        public void AbsorbRecoil() =>
            CurrentRecoil = 0;

        public void CockTheTrigger() =>
            _cockTrigger = true;

        public void Tick(float deltaTime) =>
            _stateMachine.Tick(deltaTime);            

        public void OnAfterTick()
        {
            _pullTrigger = false;
            _cockTrigger = false;
        }
    }
}
