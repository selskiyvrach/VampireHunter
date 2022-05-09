using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Zenject
{
    public class GenericComponentInstaller<T> : MonoInstaller where T : Component
    {
        [SerializeField] private T _component;

        public override void InstallBindings()
        {
            Container.Bind<T>().To<T>().FromInstance(_component);
        }
    }
}