using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Transforms.Installers
{
    public class WorldObjectInstaller : MonoInstaller
    {
        [SerializeField] private Transform _gameObject;
        
        public override void InstallBindings()
        {
            Container
                .Bind<WorldObject>()
                .To<WorldObject>()
                .FromSubContainerResolve()
                .ByMethod(Create)
                .AsSingle();
        }

        private void Create(DiContainer container)
        {
            container.Bind<Transform>().To<Transform>().FromInstance(_gameObject).AsSingle();
            container.Bind<WorldObject>().To<WorldObject>().FromNew().AsSingle();
        }
    }
}