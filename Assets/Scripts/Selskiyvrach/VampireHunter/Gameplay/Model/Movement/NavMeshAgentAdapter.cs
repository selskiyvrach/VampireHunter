using Selskiyvrach.Core.Lifecycle;
using UnityEngine;
using UnityEngine.AI;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Movement
{
    public class NavMeshAgentAdapter : LifecycleObject, IMover
    {
        private readonly NavMeshAgent _navMeshAgent;
        
        public Vector3 Destination 
        { 
            get => _navMeshAgent.destination; 
            set => _navMeshAgent.destination = value; 
        }
        
        public Vector3 Velocity => _navMeshAgent.velocity;

        public float Speed 
        { 
            get => _navMeshAgent.speed; 
            set => _navMeshAgent.speed = value; 
        }
        
        public float StoppingDistance 
        { 
            get => _navMeshAgent.stoppingDistance; 
            set => _navMeshAgent.stoppingDistance = value; 
        }

        public bool IsStopped
        {
            get => _navMeshAgent.isStopped; 
            set => _navMeshAgent.isStopped = value;
        }

        public NavMeshAgentAdapter(NavMeshAgent navMeshAgent) => 
            _navMeshAgent = navMeshAgent;
    }
}