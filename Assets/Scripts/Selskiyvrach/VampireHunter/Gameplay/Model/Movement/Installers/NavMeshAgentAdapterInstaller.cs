using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Movement.Installers
{
    public class NavMeshAgentAdapterInstaller : MonoInstaller
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        public override void InstallBindings() => 
            Container.Bind<IMover>().To<NavMeshAgentAdapter>().FromMethod(Create).AsSingle();

        private NavMeshAgentAdapter Create() => 
            new NavMeshAgentAdapter(_navMeshAgent);
    }
}