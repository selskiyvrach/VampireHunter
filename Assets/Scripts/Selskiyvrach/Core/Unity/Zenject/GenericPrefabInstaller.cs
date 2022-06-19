using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Zenject
{
    public class GenericPrefabInstaller<T> : MonoInstaller where T : Component
    {
        [SerializeField]
        private T _prefab;

        public override void InstallBindings() => 
            Container.Bind<T>().FromComponentInNewPrefab(_prefab).AsSingle().NonLazy();
    }
}