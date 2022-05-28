using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Zenject
{
    public abstract class GenericComponentInstaller<T> : MonoInstaller where T : Component
    {
        [SerializeField] private T _component;

        public override void InstallBindings() => 
            Container.Bind<T>().To<T>().FromInstance(_component);
    }

    public abstract class GenericScriptableObjectInstaller<T> : MonoInstaller where T: ScriptableObject
    {
        [SerializeField] private T _scriptableObject;

        public override void InstallBindings() => 
            Container.Bind<T>().To<T>().FromInstance(_scriptableObject);
    }
}