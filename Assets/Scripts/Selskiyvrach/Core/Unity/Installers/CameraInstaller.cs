﻿using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera _prefab;

        public override void InstallBindings() =>
            Container.Bind<Camera>().FromComponentInNewPrefab(_prefab).AsCached().NonLazy();
    }
}