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
}