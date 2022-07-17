using Selskiyvrach.VampireHunter.Gameplay.Model.Movement;
using UnityEngine.AI;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public interface ISpeedProvider
    {
        float Speed { get; }
    }

    public interface IStoppingDistanceProvider
    {
        float StoppingDistance { get; }
    }

    public class Feet : NavMeshAgentAdapter
    {
        public Feet(NavMeshAgent navMeshAgent) : base(navMeshAgent)
        {
        }
    }
}