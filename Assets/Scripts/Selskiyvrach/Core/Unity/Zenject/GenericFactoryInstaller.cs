using Zenject;

namespace Selskiyvrach.Core.Unity.Zenject
{
    public abstract class GenericFactoryInstaller<TProduct, TFactory> : MonoInstaller where TFactory : PlaceholderFactory<TProduct>
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<TProduct, TFactory>();
        }
    }
    
    public abstract class GenericFactoryInstaller<TArg1, TProduct, TFactory> : 
        MonoInstaller where TFactory : PlaceholderFactory<TArg1, TProduct>
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<TArg1, TProduct, TFactory>();
        }
    }
    
    public abstract class GenericFactoryInstaller<TArg1, TArg2, TProduct, TFactory> : 
        MonoInstaller where TFactory : PlaceholderFactory<TArg1, TArg2, TProduct>
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<TArg1, TArg2, TProduct, TFactory>();
        }
    }
    
    public abstract class GenericFactoryInstaller<TArg1, TArg2, TArg3, TProduct, TFactory> : 
        MonoInstaller where TFactory : PlaceholderFactory<TArg1, TArg2, TArg3, TProduct>
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<TArg1, TArg2, TArg3, TProduct, TFactory>();
        }
    }
}