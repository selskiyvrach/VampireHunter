using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers.Installers
{
    public class GunslingerFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GunslingerGameObject _prefab; 
        
        public override void InstallBindings() =>
            Container.BindFactory<Gunslinger, GunslingerFactory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(_prefab);
    }
}