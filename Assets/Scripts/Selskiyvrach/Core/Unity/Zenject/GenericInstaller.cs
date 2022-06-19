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
    
    public abstract class GenericInstaller<TBind1, TBind2, TTo> : MonoInstaller where TTo : TBind1, TBind2
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(TBind1), typeof(TBind2)).To<TTo>().FromNew().AsSingle().NonLazy();
        }
    }
    
    public abstract class GenericInstaller<TBind1, TBind2, TBind3, TTo> : MonoInstaller where TTo : TBind1, TBind2, TBind3
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(TBind1), typeof(TBind2), typeof(TBind3)).To<TTo>().FromNew().AsSingle().NonLazy();
        }
    }
}