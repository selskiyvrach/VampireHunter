using Zenject;

namespace Selskiyvrach.Core.Unity.Zenject
{
    public abstract class GenericInstaller<TBind> : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TBind>().To<TBind>().FromNew().AsSingle().NonLazy();
        }
    }
    
    public abstract class GenericInstaller<TBind, TTo> : MonoInstaller where TTo : TBind
    {
        public override void InstallBindings()
        {
            Container.Bind<TBind>().To<TTo>().FromNew().AsSingle().NonLazy();
        }
    }
}