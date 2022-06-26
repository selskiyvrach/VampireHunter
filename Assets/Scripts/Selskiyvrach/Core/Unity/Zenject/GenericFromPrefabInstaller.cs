using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Zenject
{
    public class GenericFromPrefabInstaller<T> : MonoInstaller 
    {
        [SerializeField]
        private GameObject _prefab;

        public override void InstallBindings() => 
            Container.Bind<T>().FromSubContainerResolve().ByNewContextPrefab(_prefab).AsSingle().NonLazy();
    }
    
    public class GenericFromPrefabInstaller<TBind, TTo> : MonoInstaller where TTo : TBind 
    {
        [SerializeField]
        private GameObject _prefab;

        public override void InstallBindings() => 
            Container.Bind<TBind>().To<TTo>().FromSubContainerResolve().ByNewContextPrefab(_prefab).AsSingle().NonLazy();
    }
}