using System.Threading.Tasks;
using Selskiyvrach.Core.Lifecycle;
using Selskiyvrach.Core.Unity.Transforms;
using Selskiyvrach.VampireHunter.Gameplay.Model.Movement;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public class Creature : LifecycleObject, IWorldObject
    {
        public WorldObject WorldObject { get; }
        private readonly IMoverSettings _settings;
        private readonly IMover _mover;

        protected Creature(WorldObject worldObject, IMover mover, IMoverSettings settings)
        {
            WorldObject = worldObject;
            _mover = mover;
            _settings = settings;
            Initialize();
            Enable();
        }

        public override Task Initialize()
        {
            _mover.Destination = Vector3.zero;
            _mover.Speed = _settings.Speed;
            _mover.StoppingDistance = _settings.StoppingDistance;
            return base.Initialize();
        }

        public override void Enable()
        {
            base.Enable();
            _mover.IsStopped = false;
        }

        public override void Disable()
        {
            base.Disable();
            _mover.IsStopped = true;
        }
    }
}