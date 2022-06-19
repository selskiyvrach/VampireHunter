using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Cameras.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera _prefab;

        public override void InstallBindings() => 
            Container.Bind<Camera>().FromComponentInNewPrefab(_prefab).AsSingle();
    }
}