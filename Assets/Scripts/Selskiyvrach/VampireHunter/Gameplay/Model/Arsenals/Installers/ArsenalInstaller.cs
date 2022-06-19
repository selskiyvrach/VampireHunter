using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals.Installers
{
    public class ArsenalInstaller : MonoInstaller
    {
        [SerializeField] private GunConfig[] _gunConfigs;
        
        public override void InstallBindings() => 
            Container.Bind<Arsenal>().FromMethod(CreateArsenal).AsSingle();

        private Arsenal CreateArsenal() => 
            new Arsenal(_gunConfigs);
    }
}