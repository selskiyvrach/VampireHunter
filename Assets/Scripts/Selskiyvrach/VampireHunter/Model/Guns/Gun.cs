using System.Collections.Generic;
using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Controller;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Gun : ITickable, IRecoilData
    {
        private readonly IMagazine _magazine;
        private readonly ISight _sight;
        private readonly ITrigger _trigger;
        private readonly IBarrel _barrel;
        private readonly IRaycaster _raycaster;
        private readonly StateMachine _stateMachine = new StateMachine();
        private readonly IGunStats _stats;

        private bool _pullTrigger;
        private bool _cockTrigger;
        private readonly TrajectoryCreator _trajectoryCreator;

        public int Recoil => _stats.Recoil.Value;
        public int CurrentRecoil { get; private set; }
        public bool IsCocked => _trigger.IsCocked;
        public int CurrentBullets => _magazine.CurrentLoad;
        public int MagazineCapacity => _magazine.Capacity;


        public Gun(IMagazine magazine, ISight sight, ITrigger trigger, IRaycaster raycaster, IGunStats stats, IBarrel barrel, IAimingSettings aimingSettings)
        {
            _magazine = magazine;
            _sight = sight;
            _trigger = trigger;
            _raycaster = raycaster;
            _stats = stats;
            _barrel = barrel;
            _trajectoryCreator = new TrajectoryCreator(_sight, _barrel, _raycaster, aimingSettings);

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
                .OnEnter(new ActionAction(() => _magazine.Pop()
                    .Launch(new BulletLaunchData(_stats.Damage, _stats.BulletSpeed, _trajectoryCreator.Create()))))
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
            cockTriggerState.AddTransition(idleState, new TrueCondition());
            shootState.AddTransition(idleState, new TrueCondition());
            
            _stateMachine.StartState(idleState);
        }

        public void PullTheTrigger() =>
            _pullTrigger = true;

        public void AbsorbRecoil() =>
            CurrentRecoil = 0;

        public void Tick(float deltaTime) =>
            _stateMachine.Tick(deltaTime);

        public void OnAfterTick()
        {
            _pullTrigger = false;
            _cockTrigger = false;
        }

        public void CockTheTrigger() =>
            _cockTrigger = true;

        public bool PointsAtTarget() =>
            _raycaster.Raycast(_sight.GetPerfectlyAccurateRay()).HasHit;
    }
}
