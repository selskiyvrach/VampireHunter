using Selskiyvrach.Core.Lifecycle;
using Selskiyvrach.Core.Unity.Transforms;
using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;
using Selskiyvrach.VampireHunter.Gameplay.Model.Healths;
using Selskiyvrach.VampireHunter.Gameplay.Model.Movement;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public abstract class Creature : LifecycleObject, IWorldObject
    {
        public WorldObject WorldObject { get; }
        public IMover Mover { get; }
        public IHealth Health { get; }

        protected Creature(WorldObject worldObject, IMover mover, IHealth health)
        {
            WorldObject = worldObject;
            Mover = mover;
            Health = health;
        }
    }

    public class Humanoid : Creature
    {
        private HumanoidDamageModel _humanoidDamageModel;
        protected Humanoid(WorldObject worldObject, HumanoidDamageModel humanoidDamageModel, IMover mover, IHealth health) : base(worldObject, mover, health) => 
            _humanoidDamageModel = humanoidDamageModel;
    }
    
    public class Zombie : Humanoid
    {
        public Zombie(WorldObject worldObject, HumanoidDamageModel humanoidDamageModel, IMover mover, IHealth health) : base(worldObject, humanoidDamageModel, mover, health)
        {
        }
        
           
    }
}