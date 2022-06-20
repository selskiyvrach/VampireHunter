using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Unity.Zenject
{
    public abstract class GenericComponentInstaller<T> : MonoInstaller where T : Component
    {
        [SerializeField] private T _component;

        public override void InstallBindings() => 
            Container.Bind<T>().To<T>().FromInstance(_component);
    }
    public abstract class GenericComponentInstaller<TBind, TTo> : MonoInstaller where TTo : Component, TBind
    {
        [SerializeField] private TTo _component;

        public override void InstallBindings() => 
            Container.Bind<TBind>().To<TTo>().FromInstance(_component);
    }

    public abstract class GenericScriptableObjectInstaller<T> : MonoInstaller where T: ScriptableObject
    {
        [SerializeField] private T _scriptableObject;

        public override void InstallBindings() => 
            Container.Bind<T>().To<T>().FromInstance(_scriptableObject);
    }
    
    public abstract class GenericScriptableObjectInstaller<TBind, TTo> : MonoInstaller where TTo: ScriptableObject, TBind
    {
        [SerializeField] private TTo _scriptableObject;

        public override void InstallBindings() => 
            Container.Bind<TBind>().To<TTo>().FromInstance(_scriptableObject);
    }
}