using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers.Installers
{
    public class GunslingerInstaller : MonoInstaller
    {
        [SerializeField] private GunslingerGameObject _prefab; 
        
        public override void InstallBindings() =>
            Container.Bind<Gunslinger>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(_prefab).AsSingle();
    }
}    